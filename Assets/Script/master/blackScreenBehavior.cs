using UnityEngine;
using System.Collections;

public class blackScreenBehavior : MonoBehaviour {

    public float speedFade = 0.05f;

    private SpriteRenderer sprite;
    private Color alphaMax = new Color(0, 0, 0, 1);
    private bool isVisible = true;
    private bool onStart = true;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isVisible && onStart)
        {
            sprite.color = fadeOut(speedFade, sprite.color);
        }
        if(sprite.color.a <= 0)
        {
            isVisible = false;
            onStart = false;
        }

	}

    Color fadeOut(float speed, Color color)
    {

        return color - (alphaMax * speed);
    }
}
