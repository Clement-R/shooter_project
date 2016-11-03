using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour {
    public int speed;

    private Rigidbody2D rb2d;

    void Start() {
        Destroy(this, 3.0f);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector2 bulletForce = transform.up * speed;
        rb2d.velocity = bulletForce;
    }
    
    void OnTriggerEnter2D(Collider2D coll) {
        Destroy(this);
        Destroy(coll.gameObject);
    }
}