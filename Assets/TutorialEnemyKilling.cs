using UnityEngine;
using System.Collections;

public class TutorialEnemyKilling : MonoBehaviour {
    public GameObject enemy;
    public float timeBeforeFail = 5.0f;

    private EventBehavior eventManager;
    private GameObject trashInstance;
    private EnemyBehavior_master behavior;
    private float nextFail = 0.0F;

    void Start () {
        eventManager = GetComponent<EventBehavior>();
        trashInstance = Instantiate(enemy, this.transform) as GameObject;
        trashInstance.transform.position = new Vector3(3.5f, -9.0f, 0.0f);
        trashInstance.GetComponent<EnemyMovement_master>().speed = 0.0f;
        trashInstance.GetComponent<CircleCollider2D>().isTrigger = false;
        behavior = trashInstance.GetComponent<EnemyBehavior_master>();
        behavior.isTargeted = true;

        nextFail = Time.time + timeBeforeFail;
    }
	
	void Update () {
        if (!behavior.isTargeted) {
            eventManager.success = true;
        }

        if (Time.time > nextFail && !eventManager.success) {
            nextFail = Time.time + timeBeforeFail;
            eventManager.fail = true;
        }
    }
}
