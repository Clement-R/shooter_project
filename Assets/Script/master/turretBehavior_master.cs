using UnityEngine;
using System.Collections;

public class turretBehavior_master : MonoBehaviour {

    public Sprite middleSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = middleSprite;
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
        

        if(Input.GetAxisRaw("Horizontal_2") < 0)
        {
            GetComponent<SpriteRenderer>().sprite = leftSprite;
        } else if (Input.GetAxisRaw("Horizontal_2") > 0)
        {
            GetComponent<SpriteRenderer>().sprite = rightSprite;
        } else
        {
            GetComponent<SpriteRenderer>().sprite = middleSprite;
        }
        
    }
}
