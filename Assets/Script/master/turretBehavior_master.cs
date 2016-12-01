using UnityEngine;
using System.Collections;

public class turretBehavior_master : MonoBehaviour {

    public Sprite middleSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = middleSprite;
    }

    void FixedUpdate()
    {
        //A supprimer, permet de faire les tests au clavier
        // transform.FindChild("pivotScope").transform.eulerAngles += Vector3.back * Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Horizontal_2") < 0)
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
