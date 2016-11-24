using UnityEngine;
using XInputDotNetPure;

public class VibrationCommunication : MonoBehaviour {

	// Update is called once per frame
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
