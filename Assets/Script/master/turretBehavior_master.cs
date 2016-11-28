using UnityEngine;
using System.Collections;

public class turretBehavior_master : MonoBehaviour {

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var angle = Mathf.Atan2(Input.GetAxisRaw("Horizontal_2"), -Input.GetAxisRaw("Vertical_2")) * Mathf.Rad2Deg;

        // QUICKFIX - Angle = 180 if there is no input
        if (angle == 180)
        {
            angle = 0;
        }
        if(angle > 90)
        {
            angle = 90;
        }
        if(angle < -90)
        {
            angle = -90;
        }

        transform.FindChild("pivotScope").transform.localEulerAngles = new Vector3(0, 0, -angle);
    }
}
