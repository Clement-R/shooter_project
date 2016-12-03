using UnityEngine;
using System.Collections;

public class ShuttleBehavior_master : MonoBehaviour {
    public float stunCooldown;
    public float stunMovement;

    [HideInInspector]
    public bool isStuned = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "trash")
        {
            if (!isStuned)
            {
                //Bounce
                float h = Input.GetAxisRaw("Horizontal_1");
                float v = -Input.GetAxisRaw("Vertical_1");
                transform.position += new Vector3(h * stunMovement * -1, v * stunMovement * -1, 0);

                isStuned = true;
                StartCoroutine("stunEffect");
                coll.gameObject.GetComponent<TrashBehavior_master>().Die();
            }
        }
        else if (coll.gameObject.tag == "enemy")
        {
            if (!isStuned)
            {
                //Bounce
                float h = Input.GetAxisRaw("Horizontal_1");
                float v = -Input.GetAxisRaw("Vertical_1");
                transform.position += new Vector3(h * stunMovement * -1, v * stunMovement * -1, 0);

                isStuned = true;
                StartCoroutine("stunEffect");
            }
        }

    }

    void Update()
    {
        if (this.isStuned)
        {
            StartCoroutine("effect");
        }
        else
        {
            StopCoroutine("effect");
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public IEnumerator stunEffect()
    {
        yield return new WaitForSeconds(stunCooldown);
        isStuned = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public IEnumerator effect()
    {
        if (GetComponent<SpriteRenderer>().enabled == false)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(0.25f);
        StartCoroutine("effect");
    }
}
