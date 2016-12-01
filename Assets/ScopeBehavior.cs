using UnityEngine;
using System.Collections;

public class ScopeBehavior : MonoBehaviour {
    
	void FixedUpdate () {
        var angle = Mathf.Atan2(Input.GetAxisRaw("Horizontal_2"), -Input.GetAxisRaw("Vertical_2")) * Mathf.Rad2Deg;

        // QUICKFIX - Angle = 180 if there is no input
        if (angle == 180) {
            angle = 0;
        }

        angle = Mathf.Clamp(angle, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}
