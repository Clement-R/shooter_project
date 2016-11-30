using UnityEngine;
using System.Collections;

public class eventailBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void resetAnimation()
    {
        GetComponent<Animator>().SetBool("playAnimation", false);
    }
}
