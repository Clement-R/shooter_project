using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class VibrationExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.leftP1, 1.0f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.rightP1, 1.0f);
        }
        
        if(GamePad.GetState((PlayerIndex)0).Triggers.Left > 0)
        {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.leftP2, GamePad.GetState((PlayerIndex)0).Triggers.Left);
        }
        if (GamePad.GetState((PlayerIndex)0).Triggers.Right > 0)
        {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.rightP2, GamePad.GetState((PlayerIndex)0).Triggers.Right);
        }

        if (GamePad.GetState((PlayerIndex)1).Triggers.Left > 0)
        {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.leftP1, GamePad.GetState((PlayerIndex)1).Triggers.Left);
        }
        if (GamePad.GetState((PlayerIndex)1).Triggers.Right > 0)
        {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.rightP1, GamePad.GetState((PlayerIndex)1).Triggers.Right);
        }

    }
}
