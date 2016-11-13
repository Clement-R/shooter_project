using UnityEngine;
using System;
using System.Collections.Generic;


public class GameManager_WaveSpawner : MonoBehaviour
{
    public int numberOfEnemiesKilled = 0;

    private int numberOfEnemiesInWave = 0;
    private int currentWave = 0;
    private int numberOfWaves = 0;

    private GameManager_EnemySpawn_2 enemySpawner;

    private Dictionary<int, List<KeyValuePair<int, float>>> wave = new Dictionary<int, List<KeyValuePair<int, float>>>();
    

    void Start ()
    {
        enemySpawner = GetComponent<GameManager_EnemySpawn_2>();

        //Load data from disk
        TextAsset wavesData = Resources.Load("waves") as TextAsset;

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
        foreach (var wave in waves) {
            // Extract all enemies in the line
            string[] enemies = wave.Split(new string[] { "|"}, StringSplitOptions.None);

            this.wave.Add(waveIndex, new List<KeyValuePair<int, float>>());
            // Foreach enemy of the current line
            foreach (var enemy in enemies) {
                // Extract enemy data
                string[] enemyData = enemy.Split(new string[] { ";" }, StringSplitOptions.None);
                int enemyIndex = Int32.Parse(enemyData[0]);
                float enemyPosition = float.Parse(enemyData[1]);

                this.wave[waveIndex].Add(new KeyValuePair<int, float>(enemyIndex, enemyPosition));
            }

            waveIndex--;
        }
        
        sendWave();
    }
	
	void Update ()
    {
	    if(numberOfEnemiesInWave == numberOfEnemiesKilled)
        {
            currentWave ++;
            // Send next wave
            sendWave();
        }
    }

    void sendWave()
    {
        // Reset wave infos
        numberOfEnemiesInWave = 0;
        numberOfEnemiesKilled = 0;

        // Extract wave infos
        foreach (var enemy in wave[currentWave]) {
            // TODO : use enemy.Key to tell which enemy type to instantiate
            enemySpawner.spawnEnemy(enemy.Value);
            numberOfEnemiesInWave++;
        }
    }
}