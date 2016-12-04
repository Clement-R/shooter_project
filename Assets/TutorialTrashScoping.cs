using UnityEngine;
using System.Collections;

public class TutorialTrashScoping : MonoBehaviour {
    public GameObject trash;
    public float timeBeforeFail = 5.0f;

    private EventBehavior eventManager;
    private GameObject trashInstance;
    private TrashBehavior_master behavior;
    private float nextFail = 0.0F;

    void Start () {
        eventManager = GetComponent<EventBehavior>();
        trashInstance = Instantiate(trash, this.transform) as GameObject;
        trashInstance.transform.position = new Vector3(3.5f, -9.0f, 0.0f);
        trashInstance.GetComponent<EnemyMovement>().speed = 0.0f;
        trashInstance.GetComponent<BoxCollider2D>().isTrigger = false;
        behavior = trashInstance.GetComponent<TrashBehavior_master>();
        behavior.isTargeted = true;

        nextFail = Time.time + timeBeforeFail;
    }
	
	void Update () {
        if (behavior.isFocused) {
            eventManager.success = true;
        }

        if (Time.time > nextFail && !eventManager.success) {
            nextFail = Time.time + timeBeforeFail;
            eventManager.fail = true;
        }
    }
}
