using UnityEngine;
using System.Collections;

public class TutorialUpJoystick : MonoBehaviour {
    public float timeBeforeFail = 5.0f;

    private GameObject grandMa;
    private EventBehavior eventManager;
    private bool hasTouchedOnLeft = false;
    private bool hasTouchedOnRight = false;
    private float nextFail = 0.0F;

    void Start() {
        grandMa = GameObject.Find("GrandMa/pivotEventail");
        eventManager = GetComponent<EventBehavior>();
        nextFail = Time.time + timeBeforeFail;
    }

    void Update() {
        if (grandMa.transform.rotation.eulerAngles.z <= 20 && grandMa.transform.rotation.eulerAngles.z <= 340 && grandMa.transform.rotation.eulerAngles.z != 0) {
            eventManager.success = true;
        }

        if (Time.time > nextFail) {
            nextFail = Time.time + timeBeforeFail;
            eventManager.fail = true;
        }
    }
}