using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    public int speed;
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(0, 1, 0);
        transform.position += move * -speed * Time.deltaTime;
    }
}
