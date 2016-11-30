using UnityEngine;
using System.Collections;

public class TrashBehavior_master : MonoBehaviour {
    
    void Start()
    {
        Destroy(this.gameObject, 12.0f);
        GetComponent<Animator>().speed = 0;
        
    }

    public void Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().speed = 5;
        Destroy(this.gameObject, 1f);
    }
}
