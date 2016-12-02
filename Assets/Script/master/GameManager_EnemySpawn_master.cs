using UnityEngine;
using System.Collections;

public class GameManager_EnemySpawn_master : MonoBehaviour {
    public GameObject Enemy1;
    public GameObject Enemy2;
    public float ySpawn;
    private GameManager_WaveSpawner_master spawner;

    void Start()
    {
        spawner = GetComponent<GameManager_WaveSpawner_master>();
    }

    public GameObject spawnEnemy(float x)
    {
        if(x > -0.5f || x < 0.5f)
        {
            return Instantiate(Enemy1, new Vector3(x, ySpawn, 0), Quaternion.identity) as GameObject;
        } else
        {
            return Instantiate(Enemy2, new Vector3(x, ySpawn, 0), Quaternion.identity) as GameObject;
        }
    }

    void Update()
    {
    }
}
