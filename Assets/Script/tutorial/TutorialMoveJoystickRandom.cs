using UnityEngine;
using System.Collections;

public class TutorialMoveJoystickRandom : MonoBehaviour {
    public float timeBeforeFail = 5.0f;

    private GameObject grandMa;
    private EventBehavior eventManager;
    private bool hasTouched = false;
    private float nextFail = 0.0F;

    void Start() {
        grandMa = GameObject.Find("GrandMa/pivotEventail");
        eventManager = GetComponent<EventBehavior>();
        nextFail = Time.time + timeBeforeFail;
    }

    void Update() {
        if (grandMa.transform.rotation.eulerAngles.z != 0) {
            hasTouched = true;
        }
        
        if (hasTouched) {
            eventManager.success = true;
        }

        if (Time.time > nextFail) {
            nextFail = Time.time + timeBeforeFail;
            eventManager.fail = true;
        }
    }
}
