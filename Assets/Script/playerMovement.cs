using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    public float speed;

    private bool isBlockLeft;
    private bool isBlockRight;
    private bool isBloghtUp;
    private bool isBlockDOwn;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(up))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed, gameObject.transform.position.z);
            setAnimator('y', 1);
        }
        if (Input.GetKey(down))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - speed, gameObject.transform.position.z);
            setAnimator('y', -1);
        }
        if(!Input.GetKey(up) && !Input.GetKey(down))
        {
            setAnimator('y', 0);
        }

        if (Input.GetKey(left))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed, gameObject.transform.position.y, gameObject.transform.position.z);
            setAnimator('x', -1);
        }
        if (Input.GetKey(right))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed, gameObject.transform.position.y,  gameObject.transform.position.z);
            setAnimator('x', 1);
        }
        if(!Input.GetKey(left) && !Input.GetKey(right)){
            setAnimator('x', 0);
        }

        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Camera.main.transform.position.z);
	}

    void setAnimator(char axis, int value)
    {
        if(axis == 'x')
        {
            gameObject.GetComponent<Animator>().SetInteger("movX", value);
        }
        if(axis == 'y')
        {
            gameObject.GetComponent<Animator>().SetInteger("movY", value);
        }

    }
}
