using UnityEngine;
using System.Collections;

public class PartSequencer : MonoBehaviour {
    public GameObject[] parts;

    private int partIndex = 0;
    private PartManager actualPart = null;

	void Start () {
        actualPart = parts[partIndex].GetComponent<PartManager>();
	}
	
	void Update () {
	    if(actualPart.isFinished) {
            partIndex++;
            Destroy(actualPart.gameObject);
            actualPart = parts[partIndex].GetComponent<PartManager>();
        }
	}
}
