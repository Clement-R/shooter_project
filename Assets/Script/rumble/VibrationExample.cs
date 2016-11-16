using UnityEngine;
using System.Collections;

public class VibrationExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.leftP1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.rightP1);
        }
	
	}
}
