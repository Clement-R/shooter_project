using UnityEngine;
using System.Collections;

public class GameManager_EnemySpawn_master : MonoBehaviour {
    public GameObject Enemy;
    public float ySpawn;
    private GameManager_WaveSpawner_master spawner;

    void Start()
    {
        spawner = GetComponent<GameManager_WaveSpawner_master>();
    }

    public GameObject spawnEnemy(float x)
    {
        // TODO : Manage enemy type
        return Instantiate(Enemy, new Vector3(x, ySpawn, 0), Quaternion.identity) as GameObject;
    }

    void Update()
    {
    }
}
