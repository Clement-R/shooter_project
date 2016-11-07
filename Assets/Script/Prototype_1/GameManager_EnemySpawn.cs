using UnityEngine;
using System.Collections;

public class GameManager_EnemySpawn_2 : MonoBehaviour {
    public GameObject Enemy;

    private GameObject actualEnemy;

    void Start ()
    {
        actualEnemy = spawnEnemy();
    }

    GameObject spawnEnemy()
    {
        return Instantiate(Enemy, new Vector3(Random.Range(-4.0f, 4.0f), 5.4f, 0), Quaternion.identity) as GameObject;
    }

    void Update()
    {
        if(actualEnemy == null)
        {
            actualEnemy = spawnEnemy();
        }
    }
}
