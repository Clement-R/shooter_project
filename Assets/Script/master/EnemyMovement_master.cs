using UnityEngine;
using System.Collections;

public class EnemyMovement_master : MonoBehaviour {
    public float speed;
    public float rotateSpeed;

    //private Rigidbody2D rb2d;

    void Start()
    {
        //rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += Vector3.down * speed;
        /* Des problemes pour faire pivoter l'objet s'il a un force qui le pousse vers le bas
        Vector2 bulletForce = -transform.up * speed;
        rb2d.velocity = bulletForce;
        */
        transform.eulerAngles += Vector3.back * rotateSpeed;
    }
}
