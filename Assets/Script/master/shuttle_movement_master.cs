using UnityEngine;
using System.Collections;

public class shuttle_movement_master : MonoBehaviour {
    public float hMaxSpeed = 175f;
    public float vMaxSpeed = 150f;

    public float speedStunnedPercent = 0.5f;

    private Rigidbody2D rb2d;
    private float h;
    private float v;

    // Use this for initialization
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        h = Input.GetAxisRaw("Horizontal_1");
        v = -Input.GetAxisRaw("Vertical_1");
        if (GetComponent<ShuttleBehavior_master>().isStuned)
        {
            rb2d.velocity = new Vector2(h * hMaxSpeed * speedStunnedPercent * Time.deltaTime, v * vMaxSpeed * speedStunnedPercent * Time.deltaTime);
        } else
        {
            rb2d.velocity = new Vector2(h * hMaxSpeed * Time.deltaTime, v * vMaxSpeed * Time.deltaTime);
        }
        if (h != 0 || v != 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, (Mathf.Atan2(-h, v) * 180) / Mathf.PI);
            GetComponent<Animator>().speed = 1;
        } else
        {
            GetComponent<Animator>().speed = 0;
        }
    }

    
}
