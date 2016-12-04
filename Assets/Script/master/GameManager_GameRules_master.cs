using UnityEngine;
using System.Collections;

public class GameManager_GameRules_master : MonoBehaviour
{
    bool gameLost = false;
    


    public int lifeInit;
    public int levelLife = 4; //Vie du monde
    public Transform cadreLoose;
    public Transform cadrePause;
    public Transform credits;

    private int life;
    private SpriteRenderer blackScreen;
    private bool deathMenuVisible = false;
    [HideInInspector]
    public bool pauseMenuVisible = false;

    private Color alphaMax = new Color(0, 0, 0, 1);


    void Start()
    {
        life = lifeInit;
        blackScreen = transform.FindChild("Blackscreen").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!gameLost)
        {
            if (Input.GetButton("Start_1") && !pauseMenuVisible)
            {
                pauseMenuVisible = true;
                Instantiate(cadrePause.gameObject, transform);
            }
        }
        if (life < 0 || gameLost)
        {
            Time.timeScale = 0.0f;
            
            if(blackScreen.color.a >= 1)
            {
                if (!deathMenuVisible)
                {
                    deathMenuVisible = true;
                    deathMenu();
                }
            }
            else
            {
                blackScreen.color = fadeIn(0.025f, blackScreen.color);
            }
        }
    }

    public void loose()
    {
        this.gameLost = true;

    }

    public void ennemyShot()
    {

    }

    public void playerTouched()
    {
        life--;
        Debug.Log("Vie restante : " + life);
        if (life == 0)
        {
            loose();
        }
    }

    public void ennemyPassed()
    {
        levelLife--;
    }


    Color fadeIn(float speed, Color color)
    {

        return color + (alphaMax * speed);
    }

    void deathMenu()
    {
        Instantiate(cadreLoose.gameObject);
    }
}