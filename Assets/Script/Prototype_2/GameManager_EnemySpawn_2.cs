using UnityEngine;
using System.Collections;

public class GameManager_EnemySpawn_2 : MonoBehaviour {
    public GameObject Enemy;

    private GameManager_WaveSpawner spawner;

    void Start() {
        spawner = GetComponent<GameManager_WaveSpawner>();
    }

    public GameObject spawnEnemy(float x) {
        // TODO : Manage enemy type
        return Instantiate(Enemy, new Vector3(x, 5.4f, 0), Quaternion.identity) as GameObject;
    }

    void Update() {
    }
}
