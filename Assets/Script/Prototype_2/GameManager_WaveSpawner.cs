using UnityEngine;
using System.Collections;

public class GameManager_WaveSpawner : MonoBehaviour
{
    private int numberOfEnemiesInWave = 0;
    private int numberOfEnemiesKilled = 0;
    private int currentWave = 0;

    void Start ()
    {
        //Load data from disk
        TextAsset wavesData = Resources.Load("waves") as TextAsset;
        Debug.Log(wavesData.text);

        /*
        map<String><map<int><float>>
        0 :
            1, 1.0f
            1, 2.0f
        1:
            1, 3.0f
            2, 2.0f
        */

        // Save data in a map of map
        //
        // Reverse the array
        //

        sendWave();
    }
	
	// Update is called once per frame
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
    }
}