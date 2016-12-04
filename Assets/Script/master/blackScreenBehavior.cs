using UnityEngine;
using System.Collections;

public class blackScreenBehavior : MonoBehaviour {

    public float speedFade = 0.05f;

    private SpriteRenderer sprite;
    private Color alphaMax = new Color(0, 0, 0, 1);

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = true;
        Destroy(gameObject, 10f);
	}
	
	// Update is called once per frame
	void Update () {
       
        sprite.color = fadeOut(speedFade, sprite.color);
	}

    Color fadeOut(float speed, Color color)
    {

        return color - (alphaMax * speed);
    }
}
