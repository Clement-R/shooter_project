using UnityEngine;
using System.Collections;

public class ShuttleMovement : MonoBehaviour {
    public int speed;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal_1"), -Input.GetAxis("Vertical_1"), 0);
        transform.position += move * speed * Time.deltaTime;
    }
}
