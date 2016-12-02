using UnityEngine;
using System.Collections;

public class ProjectileBehavior_master : MonoBehaviour {
    public int speed;

    private Rigidbody2D rb2d;

    void Start()
    {
        Destroy(this, 3.0f);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GetComponent<Animator>().GetBool("isDead") == false)
        {
            Vector2 bulletForce = transform.up * speed;
            rb2d.velocity = bulletForce;
        } else
        {
            rb2d.velocity = Vector2.zero;
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == "enemy")
        {
            GetComponent<Animator>().SetBool("isDead", true);
            coll.GetComponent<EnemyBehavior_master>().Die();
            Destroy(gameObject, .5f);
        }
        else if (coll.gameObject.tag == "trash")
        {
            GetComponent<Animator>().SetBool("isDead", true);
            
            coll.GetComponent<TrashBehavior_master>().Die();
            Destroy(gameObject, .5f);
        }
    }

    void destroyOnEnd()
    {
        Destroy(gameObject);
    }
}
