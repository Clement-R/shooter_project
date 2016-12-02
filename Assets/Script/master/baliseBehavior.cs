using UnityEngine;
using System.Collections;

public class baliseBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += Vector3.up * Mathf.Cos( 5 * Time.time - 5) * 0.1f;
	
	}
}
