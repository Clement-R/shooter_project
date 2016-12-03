using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour {
    private Transform background;
    private Transform titre;
    private Transform logo;
    private Transform start;
    private Transform credits;
    private Transform partieRapide;
    private Transform nuage1;
    private Transform nuage2;
    private Transform nuage3;
    private Transform nuage4;
    private Transform nuage5;
    private Transform cadreCarton;
    private Transform texteCarton;
    private Transform fondCredit;
    private Transform nomsCredit;


    private string state;
    private float timer;
    private bool transition = false;

    //Reference. Evite d'allouer de la mémoire a chaque fois que ces vecteurs sont necessaires
    private Color alphaMax = new Color(0, 0, 0, 1);
    private Color blackWithoutAlpha = new Color(1, 1, 1, 0);
    private Vector3 scaleMax = new Vector3(1.5f, 1.5f, 1);
    private Vector3 scaleNormal = new Vector3(1, 1, 1);

	// Use this for initialization
	void Start () {
        timer = 0f;
        background = transform.Find("Background");
        titre = transform.Find("Titre");
        logo = transform.Find("Logo");
        start = transform.Find("Start");
        credits = transform.Find("Credits");
        partieRapide = transform.Find("PartieRapide");
        nuage1 = transform.Find("Nuage1");
        nuage2 = transform.Find("Nuage2");
        nuage3 = transform.Find("Nuage3");
        nuage4 = transform.Find("Nuage4");
        nuage5 = transform.Find("Nuage5");
        cadreCarton = transform.Find("Cadre-Carton");
        texteCarton = transform.Find("Texte-Carton");
        nomsCredit = transform.Find("Noms-Credits");
        fondCredit = transform.Find("Fond-Credits");
        state = null;
        transform.DetachChildren();
        DontDestroyOnLoad(cadreCarton.gameObject);
        DontDestroyOnLoad(texteCarton.gameObject);
        
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(state == null)
        {
            moveClouds(0.1f);
        } else if (state == "Start")
        {
            start.localScale = selectionByScaleVariation(start.localScale);
            if(Input.GetAxisRaw("Vertical_1") > 0.3f && !transition)
            {
                transition = true;
                start.localScale = Vector3.one;
                state = "PartieRapide";
            }
            if(Input.GetAxisRaw("Vertical_1") == 0)
            {
                transition = false;
            }
            if (Input.GetButton("Fire_1"))
            {
                state = "lancementTuto";
            }
        } else if(state == "PartieRapide")
        {
            partieRapide.localScale = selectionByScaleVariation(partieRapide.localScale);
            if (Input.GetAxisRaw("Vertical_1") > 0.3f && !transition)
            {
                transition = true;
                partieRapide.localScale = Vector3.one;
                state = "Credits";
            }
            if (Input.GetAxisRaw("Vertical_1") < -0.3f && !transition)
            {
                transition = true;
                partieRapide.localScale = Vector3.one;
                state = "Start";
            }
            if(Input.GetAxisRaw("Vertical_1") == 0)
            {
                transition = false;
            }
            if (Input.GetButton("Fire_1"))
            {
                state = "lancementPartieRapide";
                
            }
        } else if(state == "Credits")
        {
            credits.localScale = selectionByScaleVariation(credits.localScale);
            if (Input.GetAxisRaw("Vertical_1") < -0.3f && !transition)
            {
                transition = true;
                credits.localScale = Vector3.one;
                state = "PartieRapide";
            }
            if(Input.GetAxisRaw("Vertical_1") == 0)
            {
                transition = false;
            }
            if (Input.GetButton("Fire_1"))
            {
                state = "lancementCredits";
            }
        } else if(state == "lancementPartieRapide")
        {
            transitionPartieRapide();
        } else if(state == "lancementCredits")
        {
            afficherCredits();
        } else if(state == "afficherMenu")
        {
            if (nomsCredit.GetComponent<SpriteRenderer>().color.a > 0)
            {
                start.GetComponent<SpriteRenderer>().color = fadeIn(0.05f, start.GetComponent<SpriteRenderer>().color);
                partieRapide.GetComponent<SpriteRenderer>().color = fadeIn(0.05f, partieRapide.GetComponent<SpriteRenderer>().color);
                credits.GetComponent<SpriteRenderer>().color = fadeIn(0.05f, credits.GetComponent<SpriteRenderer>().color);
                background.GetComponent<SpriteRenderer>().color = fadeIn(0.05f, background.GetComponent<SpriteRenderer>().color);
                nomsCredit.GetComponent<SpriteRenderer>().color = fadeOut(0.05f, nomsCredit.GetComponent<SpriteRenderer>().color);
                fondCredit.GetComponent<SpriteRenderer>().color = fadeOut(0.05f, fondCredit.GetComponent<SpriteRenderer>().color);
            } else
            {
                state = "Start";
            }
        } else if (state == "lancementTuto")
        {
            transitionTuto();
        }
	}

    void afficherCredits()
    {

        if (start.GetComponent<SpriteRenderer>().color.a > 0)
        {
            start.GetComponent<SpriteRenderer>().color = fadeOut(0.05f, start.GetComponent<SpriteRenderer>().color);
            partieRapide.GetComponent<SpriteRenderer>().color = fadeOut(0.05f, partieRapide.GetComponent<SpriteRenderer>().color);
            credits.GetComponent<SpriteRenderer>().color = fadeOut(0.05f, credits.GetComponent<SpriteRenderer>().color);
            background.GetComponent<SpriteRenderer>().color = fadeOut(0.05f, background.GetComponent<SpriteRenderer>().color);
            nomsCredit.GetComponent<SpriteRenderer>().color = fadeIn(0.05f, nomsCredit.GetComponent<SpriteRenderer>().color);
            fondCredit.GetComponent<SpriteRenderer>().color = fadeIn(0.05f, fondCredit.GetComponent<SpriteRenderer>().color);
        } else
        {
            if (Input.GetButton("Fire_1"))
            {
                state = "afficherMenu";
            }
        }

    }

    void transitionPartieRapide()
    {

        partieRapide.GetComponent<SpriteRenderer>().color = selectionByFade(partieRapide.GetComponent<SpriteRenderer>().color);
        if(background.GetComponent<SpriteRenderer>().color.r > 0)
        {
            darkenAll();
        } else
        {
            enlightCarton();
        }

        if(cadreCarton.GetComponent<SpriteRenderer>().color.a > 1)
        {
            if (Input.GetButton("Fire_1"))
            {

                Destroy(texteCarton.gameObject, 1.0f);
                Destroy(cadreCarton.gameObject, 1.0f);
                SceneManager.LoadScene("master");
            }
        }
    }

    void transitionTuto()
    {
        start.GetComponent<SpriteRenderer>().color = selectionByFade(start.GetComponent<SpriteRenderer>().color);
        if(background.GetComponent<SpriteRenderer>().color.r > 0)
        {
            darkenAll();
        } else
        {
            enlightCarton();
        }

        if(cadreCarton.GetComponent<SpriteRenderer>().color.a > 1)
        {
            if (Input.GetButton("Fire_1"))
            {
                Destroy(texteCarton.gameObject, 1.0f);
                Destroy(cadreCarton.gameObject, 1.0f);
                SceneManager.LoadScene("tutorial");
            }
        }
    }

    void moveClouds(float speed)
    {
        if (timer < 5f)
        {
            nuage1.position += Vector3.left * speed;
            nuage2.position += Vector3.right * speed;
            nuage3.position += Vector3.left * speed;
            nuage4.position += Vector3.right * speed;
            nuage5.position += Vector3.left * speed;
        } 
        if(timer > 3f && timer < 4f)
        {
            titre.GetComponent<SpriteRenderer>().color =  fadeOut(0.05f, titre.GetComponent<SpriteRenderer>().color);
            logo.GetComponent<SpriteRenderer>().color = fadeOut(0.05f, logo.GetComponent<SpriteRenderer>().color);
        }
        if(timer > 3.5f && timer < 4.5f)
        {
            start.GetComponent<SpriteRenderer>().color = fadeIn(0.05f, start.GetComponent<SpriteRenderer>().color);
        }
        if(timer > 4f && timer < 5f)
        {
            partieRapide.GetComponent<SpriteRenderer>().color = fadeIn(0.05f, partieRapide.GetComponent<SpriteRenderer>().color);
        }
        if(timer > 4.5f && timer < 5.5f)
        {

            credits.GetComponent<SpriteRenderer>().color = fadeIn(0.05f, credits.GetComponent<SpriteRenderer>().color);
        }
        if(timer > 5f && timer < 6f)
        {
            state = "Start";
        }
    }

    Color fadeOut(float speed, Color color)
    {
      
            return color - (alphaMax * speed);
    }

    Color fadeIn(float speed, Color color)
    {
   
            return color + (alphaMax * speed);
    }

    Color selectionByFade(Color color)
    {
        if (Mathf.Floor(timer*10) % 2 == 0)
        {
            return fadeOut(1f, color);
        }
        else
        {
            return fadeIn(1f, color);
        }
    }

    Vector3 selectionByScaleVariation(Vector3 scale)
    {
        if(Mathf.Floor(timer*3)%2 == 0)
        {
            return scale * 1.01f;
        } else
        {
            return scale * 0.99f;
        }
    }

    void darkenAll()
    {
        background.GetComponent<SpriteRenderer>().color = darken(background.GetComponent<SpriteRenderer>().color);
        start.GetComponent<SpriteRenderer>().color = darken(start.GetComponent<SpriteRenderer>().color);
        partieRapide.GetComponent<SpriteRenderer>().color = darken(partieRapide.GetComponent<SpriteRenderer>().color);
        credits.GetComponent<SpriteRenderer>().color = darken(credits.GetComponent<SpriteRenderer>().color);

    }

    Color darken(Color color)
    {
        return color - ( blackWithoutAlpha* .01f);
    }

    void enlightCarton()
    {
        texteCarton.GetComponent<SpriteRenderer>().color = fadeIn(0.1f, texteCarton.GetComponent<SpriteRenderer>().color);
        cadreCarton.GetComponent<SpriteRenderer>().color = fadeIn(0.1f, cadreCarton.GetComponent<SpriteRenderer>().color);
    }
}
