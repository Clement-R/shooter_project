using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
    public GameObject deathSound;

    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 12.0f);
	}

    public void Die()
    {
        // Play sound
        GameObject deathSoundEmitter = Instantiate(deathSound);
        deathSoundEmitter.transform.position = gameObject.transform.position;
        
        // Destroy game object
        Destroy(this.gameObject);
    }
}
