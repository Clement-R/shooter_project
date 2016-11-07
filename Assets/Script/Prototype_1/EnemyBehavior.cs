using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
    public GameObject deathSound;
    public bool isTargeted = false;

    void Start () {
        Destroy(this.gameObject, 12.0f);
	}

    void Update()
    {
        if (this.isTargeted)
        {
            StartCoroutine("effect");
        }
        else
        {
            StopCoroutine("effect");
        }
    }

    public IEnumerator effect()
    {
        if(GetComponent<SpriteRenderer>().enabled == false)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        
        yield return new WaitForSeconds(0.25f);
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
