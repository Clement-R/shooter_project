using UnityEngine;
using System.Collections;

public class scrolling_master : MonoBehaviour {

    public float scrollSpeed;
    public float sizeY;

    private bool isAlone = true;
    private GameObject neighboor;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update() {
        transform.position += Vector3.up * scrollSpeed * -1;
        if (isAlone)
        {
            neighboor = Instantiate(gameObject);
            neighboor.transform.position = transform.position + (new Vector3(0, sizeY, 0));
            neighboor.GetComponent<scrolling_master>().setIsAlone(false);
            neighboor.name = gameObject.name;
            isAlone = false;
        }
    }

    public void setIsAlone(bool l)
    {
        isAlone = l;
    }

    void OnBecameInvisible()
    {
        if (neighboor)
        {
            neighboor.GetComponent<scrolling_master>().setIsAlone(true);
        }
        Destroy(gameObject);
    }
}
