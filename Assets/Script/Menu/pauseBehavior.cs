using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseBehavior : MonoBehaviour {
    private Transform cadre;
    private Transform background;
    private Transform reprendre;
    private Transform quitter;

    private string state;
    
	// Use this for initialization
	void Start () {
        cadre = transform.FindChild("Cadre");
        background = transform.FindChild("Background");
        reprendre = transform.FindChild("Reprendre");
        quitter = transform.FindChild("Quitter");

        Time.timeScale = 0f;
        state = "reprendre";
	
	}
	
	// Update is called once per frame
	void Update () {
        if(state == "reprendre")
        {
            reprendre.localScale = selectionByScaleVariation(reprendre.localScale);
            if(Input.GetAxisRaw("Vertical_1") > .5f)
            {
                state = "quitter";
            }
        } else if (state == "quitter")
        {
            quitter.localScale = selectionByScaleVariation(quitter.localScale);
            if(Input.GetAxisRaw("Vertical_1") < -.5f)
            {
                state = "reprendre";
            }

        }

        if (Input.GetButton("Fire_1_1"))
        {
            if(state == "reprendre")
            {
                Time.timeScale = 1f;
                GetComponentInParent<GameManager_GameRules_master>().pauseMenuVisible = false;
                Destroy(gameObject);
            } else if (state == "quitter")
            {
                DontDestroyOnLoad(gameObject);
                Destroy(gameObject, 2f);
                SceneManager.LoadScene("menu");
            }
        }
	
	}

    Vector3 selectionByScaleVariation(Vector3 scale)
    {
        if (Mathf.Floor(Time.unscaledTime * 3) % 2 == 0)
        {
            return scale * 1.01f;
        }
        else
        {
            return scale * 0.99f;
        }
    }
}
