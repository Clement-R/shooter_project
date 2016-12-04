using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    public float speed;
    public float realSpeed;

    private Rigidbody2D rb2d;
    private bool isVisible = false;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        if (isVisible)
        {
            transform.position += Vector3.down * realSpeed * Time.deltaTime;

        } else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        
    }

    void OnBecameVisible()
    {
        isVisible = true;
    }
}
