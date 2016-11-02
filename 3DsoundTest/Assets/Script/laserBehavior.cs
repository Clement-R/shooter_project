using UnityEngine;
using System.Collections;

public class laserBehavior : MonoBehaviour {

    private float timeCreated;

    public float lifeTime;
    public float speed;

	// Use this for initialization
	void Start () {
        timeCreated = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed, gameObject.transform.position.z);
        if(Time.time - timeCreated > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
