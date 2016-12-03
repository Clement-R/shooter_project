using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PartSequencer : MonoBehaviour {
    public GameObject[] parts;

    private int numberOfParts = 0;
    private int partIndex = 0;
    private PartManager actualPartManager = null;
    private GameObject actualPartInstance = null;
    private bool actualPartInstantiated = false;
    
	void Update () {
        if (!actualPartInstantiated) {
            if(partIndex < parts.Length) {
                actualPartInstance = Instantiate(parts[partIndex], transform) as GameObject;
                actualPartManager = actualPartInstance.GetComponent<PartManager>();
                actualPartInstantiated = true;
            } else {
                // TODO : Go to Main Menu
                Debug.Log("THE END");
            }
        }

        if (actualPartManager.isFinished) {
            // Set up to launch the next part on the next update
            actualPartInstantiated = false;
            partIndex++;
            Destroy(actualPartInstance.gameObject);
        }
    }
}
