using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    public int speed;

    private Rigidbody2D rb2d;
    private GameManager_GameRules god;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        god = GameObject.Find("GameManager").GetComponent<GameManager_GameRules>();
    }

    void Update ()
    {
        Vector2 bulletForce = - transform.up * speed;
        rb2d.velocity = bulletForce;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "southWall") {
            god.loose();
            Destroy(this.gameObject);
        }
    }
}
