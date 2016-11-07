using UnityEngine;
using System.Collections;

public class TrashBehavior : MonoBehaviour {

    void Start() {
        Destroy(this.gameObject, 12.0f);
    }

    public void Die() {
        Destroy(this.gameObject);
    }
}
