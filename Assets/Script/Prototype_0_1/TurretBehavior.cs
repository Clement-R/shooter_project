using UnityEngine;
using System.Collections;

public class TurretBehavior : MonoBehaviour {
    public float speed;

    public KeyCode left;
    public KeyCode right;

    private Rigidbody2D rb2D;
    private AudioSource child;

    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (Input.GetKey(left)) {
            rb2D.MoveRotation(rb2D.rotation + speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(right)) {
            rb2D.MoveRotation(rb2D.rotation - speed * Time.fixedDeltaTime);
        }
    }
}
