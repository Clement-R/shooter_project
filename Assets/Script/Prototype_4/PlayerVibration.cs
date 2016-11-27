using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerVibration : MonoBehaviour {

	void Update () {
        if (GamePad.GetState((PlayerIndex)0).Triggers.Left > 0) {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.leftP2, GamePad.GetState((PlayerIndex)0).Triggers.Left);
        }
        if (GamePad.GetState((PlayerIndex)0).Triggers.Right > 0) {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.rightP2, GamePad.GetState((PlayerIndex)0).Triggers.Right);
        }

        if (GamePad.GetState((PlayerIndex)1).Triggers.Left > 0) {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.leftP1, GamePad.GetState((PlayerIndex)1).Triggers.Left);
        }
        if (GamePad.GetState((PlayerIndex)1).Triggers.Right > 0) {
            gameObject.GetComponent<Rumble>().rumble(Rumble.MotorName.rightP1, GamePad.GetState((PlayerIndex)1).Triggers.Right);
        }
    }
}
