using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class GameManager_WaveSpawner_master : MonoBehaviour {
    [HideInInspector]
    public int numberOfEnemiesKilled = 0;

    private int numberOfEnemiesInWave = 0;
    private int currentWave;
    private int numberOfWaves = 0;
    private float localTimer = 0;
    private bool creditNotVisible = true;

    private Transform credit;
    private Color alphaMax = new Color(0, 0, 0, 1);
    private GameManager_EnemySpawn_master enemySpawner;

    private Dictionary<int, List<KeyValuePair<int, Vector2>>> wave = new Dictionary<int, List<KeyValuePair<int, Vector2>>>();


    void Start()
    {
        currentWave = currentLevelStaticVariable.currentWave;
        enemySpawner = GetComponent<GameManager_EnemySpawn_master>();

        //Load data from disk
        TextAsset wavesData = Resources.Load("wave_master") as TextAsset;

        /*
        Dictionary<int><Dictionary<int><float>>
        0 : // Wave index
            1, 1.0f // Enemy index, position
            1, 2.0f // Enemy index, position
        1: // Wave index
            1, 3.0f // Enemy index, position
            2, 2.0f // Enemy index, position
        */

        // Get number of lines
        this.numberOfWaves = wavesData.text.Split('\n').Length;
        int waveIndex = this.numberOfWaves - 1;

        // Split file by lines
        string[] waves = wavesData.text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        

        // Foreach line
        foreach (var wave in waves)
        {
            // Extract all enemies in the line
            string[] enemies = wave.Split(new string[] { "|" }, StringSplitOptions.None);

            this.wave.Add(waveIndex, new List<KeyValuePair<int, Vector2>>());
            // Foreach enemy of the current line
            foreach (var enemy in enemies)
            {
                /*
                // Extract enemy data
                string[] enemyData = enemy.Split(new string[] { ";" }, StringSplitOptions.None);
                int enemyIndex = Int32.Parse(enemyData[0]);
                float enemyPosition = float.Parse(enemyData[1]);

                this.wave[waveIndex].Add(new KeyValuePair<int, float>(enemyIndex, enemyPosition));
                */
                char[] splitDelimiter = new char[] {'(',';', ')' };
                string[] enemyData = enemy.Split(splitDelimiter);
                int enemyType = Int32.Parse(enemyData[0]);
                Vector2 enemyPosition = new Vector2(float.Parse(enemyData[1]), float.Parse(enemyData[2]));
                this.wave[waveIndex].Add(new KeyValuePair<int, Vector2>(enemyType, enemyPosition));              
            }

            waveIndex--;
        }

        sendWave();
    }

    void Update()
    {
        if (numberOfEnemiesInWave == numberOfEnemiesKilled)
        {
            currentLevelStaticVariable.currentWave++;
            currentWave++;
            if (currentWave <= numberOfWaves - 1)
            {
                // Send next wave
                sendWave();
            } else
            {
                endGame();
            }
        }
    }

    void sendWave()
    {
        // Reset wave infos
        numberOfEnemiesInWave = 0;
        numberOfEnemiesKilled = 0;

        // Extract wave infos
        foreach (var enemy in wave[currentWave])
        {
            // TODO : use enemy.Key to tell which enemy type to instantiate
            enemySpawner.spawnEnemy(enemy.Key,enemy.Value.x, enemy.Value.y);
            numberOfEnemiesInWave++;
        }
    }

    void endGame()
    {
        if(localTimer > 5f)
        {
            transform.FindChild("Blackscreen").GetComponent<SpriteRenderer>().color = fadeIn(0.05f, transform.FindChild("Blackscreen").GetComponent<SpriteRenderer>().color);
        }
        if(localTimer > 6f && creditNotVisible)
        {
            creditNotVisible = false;
            credit = Instantiate(GetComponent<GameManager_GameRules_master>().credits);

        }
        if(localTimer > 10f)
        {
            DontDestroyOnLoad(credit.gameObject);
            Destroy(credit.gameObject, 2f);
            SceneManager.LoadScene("menu");
        }
        localTimer += Time.deltaTime;
    }

    Color fadeIn(float speed, Color color)
    {

        return color + (alphaMax * speed);
    }
}
