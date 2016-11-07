using UnityEngine;
using System.Collections;

public class ShuttleSoundEmitter : MonoBehaviour {

    public GameObject spawnOnLeftClick;
    public GameObject spawnOnRightClick;
    
    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject explosion = Instantiate(spawnOnLeftClick);
            explosion.transform.position = gameObject.transform.position;
        }

        if (Input.GetMouseButtonDown(1)) {
            GameObject laser = Instantiate(spawnOnRightClick);
            laser.transform.position = gameObject.transform.position; ;
        }
    }
}
