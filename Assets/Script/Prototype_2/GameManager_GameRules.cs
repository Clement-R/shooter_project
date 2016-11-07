using UnityEngine;
using System.Collections;

public class GameManager_GameRules : MonoBehaviour
{
    bool gameLost = false;

	void Start ()
    {
	}
	
	void Update ()
    {
	    if(gameLost)
        {
            Time.timeScale = 0.0f;
        }
    }

    public void loose()
    {
        this.gameLost = true;
    }
}
