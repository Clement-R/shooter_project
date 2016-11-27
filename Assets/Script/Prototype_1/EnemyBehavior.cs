using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
    public GameObject deathSound;
    public GameObject indicatorSound;
    public bool isTargeted = false;

    private GameManager_GameRules god;
    private bool effectLaunched = false;

    void Start () {
        Destroy(this.gameObject, 12.0f);
        god = GameObject.Find("GameManager").GetComponent<GameManager_GameRules>();
    }

    void Update()
    {
        if (this.isTargeted)
        {
            if(!effectLaunched) {
                effectLaunched = true;
                StartCoroutine("effect");
            }
        }
        else
        {
            effectLaunched = false;
            StopCoroutine("effect");
            // GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public IEnumerator effect()
    {
        /*
        if(GetComponent<SpriteRenderer>().enabled == false)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        */
        
        // Play sound
        GameObject indicatorSoundEmitter = Instantiate(indicatorSound);
        indicatorSoundEmitter.transform.position = gameObject.transform.position;

        yield return new WaitForSeconds(0.5f);
        StartCoroutine("effect");
    }

    public void Die()
    {
        // Play sound
        GameObject deathSoundEmitter = Instantiate(deathSound);
        deathSoundEmitter.transform.position = gameObject.transform.position;

        // Push information to the game manager
        GameObject.Find("GameManager").GetComponent<GameManager_WaveSpawner>().numberOfEnemiesKilled ++;
        god.ennemyShot();
        
        // Destroy game object
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "southWall") {
            god.ennemyPassed();
            Destroy(this.gameObject);
        } else if(coll.gameObject.tag == "Player")
        {
            god.playerTouched();
            Destroy(this.gameObject);
        }
    }
}
