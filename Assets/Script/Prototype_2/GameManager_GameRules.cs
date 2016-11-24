using UnityEngine;
using System.Collections;

public class GameManager_GameRules : MonoBehaviour
{
    bool gameLost = false;


    public int lifeInit;
    [Tooltip("Points obtenu lorsqu'un ennemi est vaincu")]
    public int pointPerHit;
    [Tooltip("Points perdu lorsqu'un ennemi a traversé l'écran")]
    public int malus;

    private int life;
    private int score;
    

	void Start ()
    {
        life = lifeInit;
        score = 0;
	}
	
	void Update ()
    {
	    if(life < 0 || gameLost)
        {
            Time.timeScale = 0.0f;
        }
    }

    public void loose()
    {
        this.gameLost = true;
    }

    public void ennemyShot()
    {
        score += pointPerHit;
        Debug.Log("Score :" + score);
    }

    public void playerTouched()
    {
        life--;
        Debug.Log("Vie restante : " + life);
    }

    public void ennemyPassed()
    {
        score -= malus;
        if(score < 0)
        {
            score = 0;
        }
        Debug.Log("Score : " + score);
    }
    
}
