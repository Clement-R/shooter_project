using UnityEngine;
using System.Collections;

public class nuageSolBehavior : MonoBehaviour {
    public float yRespawnPoint;
    public float scrollSpeed;

    private Vector3 respawnTransform;

	// Use this for initialization
	void Start () {
        respawnTransform = new Vector3(gameObject.transform.position.x, yRespawnPoint,0);
        Debug.Log(respawnTransform);
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.up * scrollSpeed * -1;

    }
    void OnBecameInvisible()
    {
        transform.localPosition = respawnTransform;
    }


}
