using UnityEngine;
using System.Collections;

public class ShuttleBehavior_master : MonoBehaviour {
    public bool isStuned = false;
    public float stunCooldown;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "trash")
        {
            if (!isStuned)
            {
                isStuned = true;
                StartCoroutine("stunEffect");
                coll.gameObject.GetComponent<TrashBehavior_master>().Die();
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
