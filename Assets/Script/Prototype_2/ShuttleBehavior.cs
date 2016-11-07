using UnityEngine;
using System.Collections;

public class ShuttleBehavior : MonoBehaviour {
    public GameObject onHitSound;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "trash") {
            // Play sound
            // GameObject onWallHitSoundEmitter = Instantiate(onHitSound);
            // onWallHitSoundEmitter.transform.position = gameObject.transform.position;

            // TODO : add stunt effect
            Debug.Log("Hit");
            coll.GetComponent<TrashBehavior>().Die();
        }
    }
}
