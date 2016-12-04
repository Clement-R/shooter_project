using UnityEngine;
using System.Collections;

public class TargetingEnemy : MonoBehaviour {

	void OnTriggerStay2D(Collider2D coll) {
        if(coll.tag == "enemy") {
            coll.gameObject.GetComponent<EnemyBehavior_master>().isFocused = true;
        }

        if(coll.tag == "trash") {
            coll.gameObject.GetComponent<TrashBehavior_master>().isFocused = true;
        }
    }
}
