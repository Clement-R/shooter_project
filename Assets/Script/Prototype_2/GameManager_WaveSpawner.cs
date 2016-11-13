using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager_WaveSpawner : MonoBehaviour
{
    private int numberOfEnemiesInWave = 0;
    private int numberOfEnemiesKilled = 0;
    private int currentWave = 0;

    private GameManager_EnemySpawn_2 enemySpawner;

    private Dictionary<int, Dictionary<int, float>> wave = new Dictionary<int, Dictionary<int, float>>();
    

    void Start ()
    {
        enemySpawner = GetComponent<GameManager_EnemySpawn_2>();

        //Load data from disk
        TextAsset wavesData = Resources.Load("waves") as TextAsset;
        Debug.Log(wavesData.text);

        /*
        Dictionary<int><Dictionary<int><float>>
        0 : // Wave index
            1, 1.0f // Enemy index, position
            1, 2.0f // Enemy index, position
        1: // Wave index
            1, 3.0f // Enemy index, position
            2, 2.0f // Enemy index, position
        */

        // Save data in a map of map
        //
        // Reverse the array
        //

        sendWave();
    }
	
	void Update ()
    {
	    if(numberOfEnemiesInWave == numberOfEnemiesKilled)
        {
            currentWave ++;
            // Send next wave
        }
    }

    void sendWave()
    {
        foreach (var enemy in wave[currentWave]) {

        }
        // For each enemy in wave[currentWave]
        // 
        // enemySpawner.spawnEnemy(float x, float y)
    }
}