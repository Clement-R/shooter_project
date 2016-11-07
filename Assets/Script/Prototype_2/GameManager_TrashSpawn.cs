using UnityEngine;
using System.Collections;

public class GameManager_TrashSpawn : MonoBehaviour {
    public GameObject trashGameObject;
    public int timeBetweenSpawn = 1;

    // Update is called once per frame
    void Start() {
        StartCoroutine("spawnTrash");
    }

    IEnumerator spawnTrash() {
        Instantiate(trashGameObject, new Vector3(Random.Range(-4.0f, 4.0f), 5.4f, 0), Quaternion.identity);
        yield return new WaitForSeconds(timeBetweenSpawn);
        StartCoroutine("spawnTrash");
    }
}
