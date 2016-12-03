using UnityEngine;
using System.Collections;

public class baliseBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.parent.position.x, 0, 0);
	
	}
	
	// Update is called once per frame
	void Update () {
        //transform.localPosition = Vector3.up * Mathf.Cos( 5 * Time.time - 5) * 0.1f;
        transform.position = new Vector3(transform.parent.position.x, Mathf.Cos(5 * Time.time - 5) * 0.1f + transform.parent.position.y, 0);
        transform.eulerAngles = Vector3.zero;
	
	}
}
