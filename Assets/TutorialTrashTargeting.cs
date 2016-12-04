using UnityEngine;
using System.Collections;

public class TutorialTrashTargeting : MonoBehaviour {
    public GameObject trash;

    private EventBehavior eventManager;
    private GameObject trashInstance;
    private TrashBehavior_master behavior;

	void Start () {
        eventManager = GetComponent<EventBehavior>();
        trashInstance = Instantiate(trash);
        trashInstance.transform.position = new Vector3(3.5f, -9.0f, 0.0f);
        trashInstance.GetComponent<EnemyMovement>().speed = 0.0f;
        behavior = trashInstance.GetComponent<TrashBehavior_master>();
    }
	
	void Update () {
	    if(behavior.isTargeted) {
            eventManager.success = true;
        }

        Time.timeScale = 1.0f;
    }
}
