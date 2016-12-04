using UnityEngine;
using System.Collections;

public class nuageSolBehavior_master : MonoBehaviour {

    public float scrollSpeed;
    public float yDisappear;
    public float yRespawn;

    private Vector3 respawnTransform;

	// Use this for initialization
	void Start () {
        respawnTransform = new Vector3(gameObject.transform.position.x, yRespawn, 0);
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up * scrollSpeed * -1 * Time.deltaTime;
        if(transform.position.y < yDisappear)
        {
            transform.position = respawnTransform;
        }

    }


}
