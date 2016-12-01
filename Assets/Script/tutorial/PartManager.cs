using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartManager : MonoBehaviour {
    public GameObject textInfo;
    public GameObject soundInfo;
    public GameObject exitEvent;
    public GameObject successText;
    public GameObject successSound;
    public GameObject failText;
    public GameObject failSound;

    private EventBehavior textInfoEvent = null;
    private EventBehavior soundInfoEvent = null;
    private EventBehavior exitEventEvent = null;
    private EventBehavior successTextEvent = null;
    private EventBehavior successSoundEvent = null;
    private EventBehavior failTextEvent = null;
    private EventBehavior failSoundEvent = null;

    private bool infosFinished = false;

    protected bool isFinished = false;

	void Start () {
        textInfoEvent = textInfo.GetComponent<EventBehavior>();
        soundInfoEvent = textInfo.GetComponent<EventBehavior>();
        exitEventEvent = textInfo.GetComponent<EventBehavior>();
    }
	
	void Update () {
        // If we didn't played the infos part
        if(!infosFinished) {
            // Play textInfo and/or soundInfo and wait for it/them to end
            if (soundInfoEvent != null && textInfoEvent != null) {
                while (!textInfoEvent.isFinished && !soundInfoEvent.isFinished) {
                }
            }
            else if (soundInfoEvent != null) {
                while (!soundInfoEvent.isFinished) {
                }
            }
            else if (textInfo != null) {
                while (!textInfoEvent.isFinished) {
                }
            }
        } else {
            // While the condition is not met, we ask the players to do one thing
            // TODO : Change with a coroutine
            while(exitEventEvent.isFinished != true) {
                if(exitEventEvent.fail) {
                    if (failText != null) {
                        Instantiate(failText);
                    }

                    if (failSound != null) {
                        Instantiate(failSound);
                    }

                    if(failText != null && failSound !=null) {
                        /*
                        while (failText.isFinished && failSound.isFinished) {

                        }
                        */
                    } else if (failSound != null) {
                        /*
                        while(soundInfo.isFinished)
                        */
                    } else if (textInfo !=null) {
                        /*
                        while (failText.isFinished)
                        */
                    }

                    exitEventEvent.fail = false;

                } else if (exitEventEvent.success) {
                    // Play successEvent
                    if (successText != null) {
                        Instantiate(successText);
                    }

                    if (successSound != null) {
                        Instantiate(successSound);
                    }

                    isFinished = true;
                }
            }

	        if(isFinished) {
                // Tell PartSequencer that this one is over
                // partSequencer.nextPart();
            }
        }
	}
}
