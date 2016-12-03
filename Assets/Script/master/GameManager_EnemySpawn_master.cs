using UnityEngine;
using System.Collections;

public class GameManager_EnemySpawn_master : MonoBehaviour {
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Obstacle;
    private GameManager_WaveSpawner_master spawner;

    void Start()
    {
        spawner = GetComponent<GameManager_WaveSpawner_master>();
    }

    public GameObject spawnEnemy(int enemyType, float x, float y)
    {
        //Ennemi
        if (enemyType == 1)
        {
            if (x > -0.5f && x < 0.5f)
            {
                return Instantiate(Enemy1, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
            }
            else
            {
                return Instantiate(Enemy2, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
            }
        } else
        {
            //Obstacle
            return Instantiate(Obstacle, new Vector3(x, y, 0), Quaternion.identity) as GameObject;

        }
    }

    void Update()
    {
    }
}
