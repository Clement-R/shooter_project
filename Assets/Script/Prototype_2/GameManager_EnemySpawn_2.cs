using UnityEngine;
using System.Collections;

public class GameManager_EnemySpawn_2 : MonoBehaviour {
    public GameObject Enemy;

    private GameObject actualEnemy;
    private GameManager_WaveSpawner spawner;

    void Start() {
        spawner = GetComponent<GameManager_WaveSpawner>();
    }

    GameObject spawnEnemy(float x, float y) {
        return Instantiate(Enemy, new Vector3(Random.Range(-4.0f, 4.0f), 5.4f, 0), Quaternion.identity) as GameObject;
    }

    void Update() {
        if (actualEnemy == null) {
            // spawner.nextWave();
        }
    }
}
