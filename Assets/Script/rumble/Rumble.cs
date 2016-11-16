using UnityEngine;
using XInputDotNetPure;
using System.Collections;

public class Rumble : MonoBehaviour {
    public enum MotorName { leftP1, leftP2, rightP1, rightP2};

    public float durationInSeconds;
    
    private PlayerIndex player1;
    private PlayerIndex player2;

    private Hashtable rumblesDuration; //Permet de connaitre le temps restant pour faire vibrer chaque moteur;

	// Use this for initialization
	void Start () {
        player1 = (PlayerIndex)0;
        player2 = (PlayerIndex)1;
        rumblesDuration = new Hashtable();
        rumblesDuration.Add(MotorName.leftP1, 0.0f);
        rumblesDuration.Add(MotorName.leftP2, 0.0f);
        rumblesDuration.Add(MotorName.rightP1, 0.0f);
        rumblesDuration.Add(MotorName.rightP2, 0.0f);

    }
	
    void OnApplicationQuit()
    {
        //Coupe tous les moteurs a la fin
        GamePad.SetVibration(player1, 0.0f, 0.0f);
        GamePad.SetVibration(player2, 0.0f, 0.0f);
    }

	// Update is called once per frame
	void Update () {
        Hashtable tmp = new Hashtable(rumblesDuration); // On ne peut modifier rumblesDuration si on le parcourt. On parcourt donc une copie
        foreach(MotorName key in tmp.Keys)
        {
            if((float)rumblesDuration[key] > 0.0f)
            {
                rumbleMotor(key, true);
                rumblesDuration[key] = (float)rumblesDuration[key] - Time.deltaTime;
            }
            else if ((float)rumblesDuration[key] < 0.0f) //On s'assure ici que le compteur ne descend pas en dessous de 0, afin d'etre initialiser lorsqu'une nouvelle vibration se declenche
            {
                rumbleMotor(key, false);
                rumblesDuration[key] = 0.0f;
            }
        }
	
	}

    public void rumble(MotorName name)
    {
        rumblesDuration[name] = durationInSeconds;
    }

    private void rumbleMotor(MotorName name, bool vibrate)
    {
        switch (name)
        {
            case MotorName.leftP1:
                if (vibrate)
                    GamePad.SetVibration(player1, 1.0f, GamePad.GetState(player1).Triggers.Right);
                else
                    GamePad.SetVibration(player1, 0.0f, GamePad.GetState(player1).Triggers.Right);
                break;
            case MotorName.leftP2:
                if (vibrate)
                    GamePad.SetVibration(player2, 1.0f, GamePad.GetState(player2).Triggers.Right);
                else
                    GamePad.SetVibration(player2, 0.0f, GamePad.GetState(player2).Triggers.Right);
                break;
            case MotorName.rightP1:
                if (vibrate)
                    GamePad.SetVibration(player1, GamePad.GetState(player1).Triggers.Left,1.0f);
                else
                    GamePad.SetVibration(player1, GamePad.GetState(player1).Triggers.Left, 0.0f);
                break;
            case MotorName.rightP2:
                if (vibrate)
                    GamePad.SetVibration(player2, GamePad.GetState(player2).Triggers.Left, 1.0f);
                else
                    GamePad.SetVibration(player2, GamePad.GetState(player2).Triggers.Left, 0.0f);
                break;
            default:
                Debug.Log("Passage non prevu ici");
                break;
        }
    }
}
