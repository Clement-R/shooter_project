using UnityEngine;
using System.Collections;

public class ShuttleBehavior : MonoBehaviour {
    public GameObject onHitSound;
    public bool isStuned = false;
    public float stundCooldown;

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "trash") {
            // Play sound
            // GameObject onWallHitSoundEmitter = Instantiate(onHitSound);
            // onWallHitSoundEmitter.transform.position = gameObject.transform.position;

            if(!isStuned)
            {
                isStuned = true;
                StartCoroutine("stunEffect");
            }

            coll.gameObject.GetComponent<TrashBehavior>().Die();
        } else if (coll.gameObject.tag == "wall" || coll.gameObject.tag == "southWall") {
            Debug.Log("COLL");
        }

        Debug.Log("COLLISION");
    }

    void Update() {
        if (this.isStuned) {
            StartCoroutine("effect");
        }
        else {
            StopCoroutine("effect");
        }
    }

    public IEnumerator stunEffect()
    {
        yield return new WaitForSeconds(stundCooldown);
        isStuned = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public IEnumerator effect() {
        if (GetComponent<SpriteRenderer>().enabled == false) {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else {
            GetComponent<SpriteRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(0.25f);
    }
}
