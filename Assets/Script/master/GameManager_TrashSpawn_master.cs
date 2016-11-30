using UnityEngine;
using System.Collections;

public class GameManager_TrashSpawn_master : MonoBehaviour {
    public int timeBetweenSpawn = 1;
    public float yRespawn;

    [HideInInspector]
    public GameObject trashGameObject;

    void Start()
    {
        StartCoroutine("spawnTrash");
    }

    IEnumerator spawnTrash()
    {
        Instantiate(trashGameObject, new Vector3(Random.Range(-4.0f, 4.0f), yRespawn, 0), Quaternion.identity);
        yield return new WaitForSeconds(timeBetweenSpawn);
        StartCoroutine("spawnTrash");
    }
}
