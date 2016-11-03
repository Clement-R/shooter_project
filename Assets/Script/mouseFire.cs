using UnityEngine;
using System.Collections;

public class mouseFire : MonoBehaviour {

    public GameObject spawnOnLeftClick;
    public GameObject spawnOnRightClick;
    
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject explosion = Instantiate(spawnOnLeftClick);
            explosion.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject laser = Instantiate(spawnOnRightClick);
            laser.transform.position = new Vector3(mousePosition.x, mousePosition.y-8, 0);
        }
	
	}
}
