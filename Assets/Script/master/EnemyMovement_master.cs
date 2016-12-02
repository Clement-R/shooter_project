using UnityEngine;
using System.Collections;

public class EnemyMovement_master : MonoBehaviour {
    public float speed;

    private Animator anim;
    private float localTime;

    //private Rigidbody2D rb2d;

    void Start()
    {
        anim = GetComponent<Animator>();
        localTime = 0f;
        //rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        /* Des problemes pour faire pivoter l'objet s'il a un force qui le pousse vers le bas
        Vector2 bulletForce = -transform.up * speed;
        rb2d.velocity = bulletForce;
        */
        if (anim.GetBool("isDead"))
        {
            localTime += Time.deltaTime;
            transform.position += Vector3.left * speed;
            transform.position += Vector3.down * speed * Mathf.Cos(localTime);

        } else
        {
            transform.position += Vector3.down * speed;
        }
        
    }
}
