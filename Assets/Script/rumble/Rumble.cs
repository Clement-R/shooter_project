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

        if((float)rumblesDuration[MotorName.leftP1] > 0.0f && (float)rumblesDuration[MotorName.rightP1] > 0.0f)
        {
            GamePad.SetVibration(player1, 1.0f, 1.0f);
            rumblesDuration[MotorName.leftP1] = (float)rumblesDuration[MotorName.leftP1] - Time.deltaTime;
            rumblesDuration[MotorName.rightP1] = (float)rumblesDuration[MotorName.rightP1] - Time.deltaTime;
        } else if((float)rumblesDuration[MotorName.leftP1] > 0.0f && (float)rumblesDuration[MotorName.rightP1] <= 0.0f)
        {
            GamePad.SetVibration(player1, 1.0f, 0.0f);
            rumblesDuration[MotorName.leftP1] = (float)rumblesDuration[MotorName.leftP1] - Time.deltaTime;
        } else if ((float)rumblesDuration[MotorName.leftP1] <= 0.0f && (float)rumblesDuration[MotorName.rightP1] > 0.0f)
        {
            GamePad.SetVibration(player1, 0.0f, 1.0f);
            rumblesDuration[MotorName.rightP1] = (float)rumblesDuration[MotorName.rightP1] - Time.deltaTime;
        } else if ((float)rumblesDuration[MotorName.leftP1] <= 0.0f && (float)rumblesDuration[MotorName.rightP1] <= 0.0f)
        {
            GamePad.SetVibration(player1, 0.0f, 0.0f);
        }


        if ((float)rumblesDuration[MotorName.leftP2] > 0.0f && (float)rumblesDuration[MotorName.rightP2] > 0.0f)
        {
            GamePad.SetVibration(player2, 1.0f, 1.0f);
            rumblesDuration[MotorName.leftP2] = (float)rumblesDuration[MotorName.leftP2] - Time.deltaTime;
            rumblesDuration[MotorName.rightP2] = (float)rumblesDuration[MotorName.rightP2] - Time.deltaTime;
        }
        else if ((float)rumblesDuration[MotorName.leftP2] > 0.0f && (float)rumblesDuration[MotorName.rightP2] <= 0.0f)
        {
            GamePad.SetVibration(player2, 1.0f, 0.0f);
            rumblesDuration[MotorName.leftP2] = (float)rumblesDuration[MotorName.leftP2] - Time.deltaTime;
        }
        else if ((float)rumblesDuration[MotorName.leftP2] <= 0.0f && (float)rumblesDuration[MotorName.rightP2] > 0.0f)
        {
            GamePad.SetVibration(player2, 0.0f, 1.0f);
            rumblesDuration[MotorName.rightP2] = (float)rumblesDuration[MotorName.rightP2] - Time.deltaTime;
        }
        else if ((float)rumblesDuration[MotorName.leftP2] <= 0.0f && (float)rumblesDuration[MotorName.rightP2] <= 0.0f)
        {
            GamePad.SetVibration(player2, 0.0f, 0.0f);
        }



    }

    public void rumble(MotorName name)
    {
        rumblesDuration[name] = durationInSeconds;
    }
}
