using UnityEngine;
using System.Collections;

public class TutorialJoystickTrigger : MonoBehaviour {
    public float timeBeforeFail = 5.0f;
    [Tooltip("0 = FOX; 1 = GRANDMA")]
    public int playerIndex = 0;
    [Tooltip("0 = LEFT; 1 = RIGHT; 2 = LEFT & RIGHT")]
    public int triggerToTest = 0;

    private EventBehavior eventManager;
    private float nextFail = 0.0F;

    void Start() {
        eventManager = GetComponent<EventBehavior>();
        nextFail = Time.time + timeBeforeFail;
    }

    void Update () {
        if (playerIndex == 0) {
            if(triggerToTest == 0) {
                if(Input.GetAxisRaw("Trigger_1_left") == 1) {
                    eventManager.success = true;
                }
            } else if (triggerToTest == 1) {
                if(Input.GetAxisRaw("Trigger_1_right") == 1) {
                    eventManager.success = true;
                }
            } else if (triggerToTest == 2) {
                if(Input.GetAxisRaw("Trigger_1_right") == 1 && Input.GetAxisRaw("Trigger_1_left") == 1) {
                    eventManager.success = true;
                }
            }
        } else {
            if (triggerToTest == 0) {
                if (Input.GetAxisRaw("Trigger_2_left") == 1) {
                    eventManager.success = true;
                }
            }
            else if (triggerToTest == 1) {
                if (Input.GetAxisRaw("Trigger_2_right") == 1) {
                    eventManager.success = true;
                }
            }
            else if (triggerToTest == 2) {
                if (Input.GetAxisRaw("Trigger_2_right") == 1 && Input.GetAxisRaw("Trigger_2_left") == 1) {
                    eventManager.success = true;
                }
            }
        }

        if (Time.time > nextFail) {
            nextFail = Time.time + timeBeforeFail;
            eventManager.fail = true;
        }
    }
}
