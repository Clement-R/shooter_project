using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class cartonLooseBehavior : MonoBehaviour {
    private Transform derniereVague;
    private Transform ecranTitre;

    private string state;


	// Use this for initialization
	void Start () {
        
        derniereVague = transform.FindChild("DerniereVague");
        ecranTitre = transform.FindChild("EcranTitre");
        state = "derniereVague";
	}
	
	// Update is called once per frame
	void Update () {
	    if(state == "ecranTitre")
        {
            ecranTitre.localScale = selectionByScaleVariation(ecranTitre.localScale);
            if(Input.GetAxisRaw("Vertical_1") < -.5f)
            {
                state = "derniereVague";
            }
        } else if(state == "derniereVague")
        {
            derniereVague.localScale = selectionByScaleVariation(derniereVague.localScale);
            if (Input.GetAxisRaw("Vertical_1") > .5f)
            {
                state = "ecranTitre";
            }
        }

        if (Input.GetButton("Fire_1_1"))
        {
            if(state == "ecranTitre")
            {
                DontDestroyOnLoad(gameObject);
                Destroy(gameObject, 2f);
                SceneManager.LoadScene("menu");
                
            } else if (state == "derniereVague")
            {
                SceneManager.LoadScene("master");
                Time.timeScale = 1.0f;
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
