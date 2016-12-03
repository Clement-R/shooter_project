using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class TutorialMoveJoystick : MonoBehaviour {

    private GameObject grandMa;
    private EventBehavior eventManager;
    private bool hasTouchedOnLeft = false;
    private bool hasTouchedOnRight = false;

    void Start () {
        grandMa = GameObject.Find("GrandMa/pivotEventail");
        eventManager = GetComponent<EventBehavior>();
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
    }
}
