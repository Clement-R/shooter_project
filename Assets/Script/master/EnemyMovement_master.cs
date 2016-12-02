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
            transform.position += Vector3.left * speed;
            transform.position += Vector3.down * speed * Mathf.Cos(localTime);

        } else
        {
            transform.position += Vector3.down * speed;
            transform.eulerAngles += Vector3.forward * rotationSpeed;
        }
        
    }
}
