using UnityEngine;
using System.Collections;

public class ShuttleMovement : MonoBehaviour {
    public int speed;
    public float hMaxSpeed = 175f;
    public float vMaxSpeed = 150f;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = this.GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate () {

        float h = Input.GetAxisRaw("Horizontal_1");
        float v = -Input.GetAxisRaw("Vertical_1");

        rb2d.velocity = new Vector2(h * hMaxSpeed, v * vMaxSpeed);
        
        /*
        if (Input.GetButton("Fire_" + ControllerIndex)) {
            weapon.fire();
        }
        */
    }
}
