using UnityEngine;
using System.Collections;

public class ProjectileBehavior_master : MonoBehaviour {

    public int speed;
    public GameObject onWallHitSound;

    private Rigidbody2D rb2d;

    void Start()
    {
        Destroy(this, 3.0f);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 bulletForce = transform.up * speed;
        rb2d.velocity = bulletForce;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "wall")
        {
            // Play sound
            GameObject onWallHitSoundEmitter = Instantiate(onWallHitSound);
            onWallHitSoundEmitter.transform.position = gameObject.transform.position;

            Destroy(this.gameObject);
        }
        else if (coll.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
            coll.GetComponent<EnemyBehavior>().Die();
        }
        else if (coll.gameObject.tag == "trash")
        {
            Destroy(this.gameObject);
            coll.GetComponent<TrashBehavior_master>().Die();
        }
    }
}
