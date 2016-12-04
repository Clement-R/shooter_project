using UnityEngine;
using System.Collections;

public class EnemyMovement_master : MonoBehaviour {
    public float speed;
    public float rotationSpeed;

    private Animator anim;
    private float localTime;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        localTime = 0f;
    }

    void Update()
    {
        if (anim.GetBool("isDead"))
        {
            localTime += Time.deltaTime;
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.position += Vector3.down * speed * Mathf.Cos(localTime) * Time.deltaTime;

        } else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
        }
        
    }
}
