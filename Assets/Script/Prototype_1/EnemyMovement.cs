using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    public float speed;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        Vector2 bulletForce = - transform.up * speed * Time.deltaTime;
        rb2d.velocity = bulletForce;
    }
}
