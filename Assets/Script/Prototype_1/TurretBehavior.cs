using UnityEngine;
using System.Collections;

public class TurretBehavior : MonoBehaviour {
    private Rigidbody2D rb2D;

    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        var angle = Mathf.Atan2(Input.GetAxisRaw("Horizontal_2"), -Input.GetAxisRaw("Vertical_2")) * Mathf.Rad2Deg;

        // QUICKFIX - Angle = 180 if there is no input
        if (angle == 180) {
            angle = 0;
        }

        angle = Mathf.Clamp(angle, -90, 90);
        rb2D.MoveRotation(-angle);
    }
}
