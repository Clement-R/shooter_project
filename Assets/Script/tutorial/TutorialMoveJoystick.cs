using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class TutorialMoveJoystick : MonoBehaviour {
    public float timeBeforeFail = 5.0f;

    private GameObject grandMa;
    private EventBehavior eventManager;
    private bool hasTouchedOnLeft = false;
    private bool hasTouchedOnRight = false;
    private float nextFail = 0.0F;

    void Start () {
        grandMa = GameObject.Find("GrandMa/pivotEventail");
        eventManager = GetComponent<EventBehavior>();
        nextFail = Time.time + timeBeforeFail;
    }
	
	void Update () {
        if(grandMa.transform.rotation.eulerAngles.z >= 45) {
            hasTouchedOnLeft = true;
        }

        if (grandMa.transform.rotation.eulerAngles.z >= 225) {
            hasTouchedOnRight = true;
        }

        if(hasTouchedOnLeft && hasTouchedOnRight) {
            eventManager.success = true;
        }

        if (Time.time > nextFail && !eventManager.success) {
            nextFail = Time.time + timeBeforeFail;
            eventManager.fail = true;
        }
    }
}
