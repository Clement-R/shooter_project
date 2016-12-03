using UnityEngine;
using System.Collections;

public class TutorialJoystickFoxButtons : MonoBehaviour {
    public float timeBeforeFail = 5.0f;

    private float nextFail = 0.0F;
    private EventBehavior eventManager;

    void Start() {
        eventManager = GetComponent<EventBehavior>();
        nextFail = Time.time + timeBeforeFail;
    }

    void Update () {
        if ((Input.GetButton("Fire_1_1") || Input.GetButton("Fire_1_2") || Input.GetButton("Fire_1_3") || Input.GetButton("Fire_1_4"))) {
            eventManager.success = true;
        }

        if (Time.time > nextFail) {
            nextFail = Time.time + timeBeforeFail;
            eventManager.fail = true;
        }
    }
}
