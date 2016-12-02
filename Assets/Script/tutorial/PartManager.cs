using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartManager : MonoBehaviour {
    public GameObject textInfo;
    public string text;
    public GameObject soundInfo;
    public string soundIndex;
    public GameObject exitEvent;
    public GameObject successText;
    public GameObject successSound;
    public GameObject failText;
    public GameObject failSound;

    public bool isFinished = false;

    private EventBehavior textInfoEvent = null;
    private EventBehavior soundInfoEvent = null;
    private EventBehavior exitEventEvent = null;
    private EventBehavior successTextEvent = null;
    private EventBehavior successSoundEvent = null;
    private EventBehavior failTextEvent = null;
    private EventBehavior failSoundEvent = null;

    private bool infosCoroutineLaunched = false;
    private bool infosFinished = false;
    private bool conditionCoroutineLaunched = false;

	void Start () {
        textInfoEvent = textInfo.GetComponent<EventBehavior>();
        soundInfoEvent = soundInfo.GetComponent<EventBehavior>();
        exitEventEvent = exitEvent.GetComponent<EventBehavior>();
        successTextEvent = successText.GetComponent<EventBehavior>();
        successSoundEvent = successSound.GetComponent<EventBehavior>();
        failTextEvent = failText.GetComponent<EventBehavior>();
        failSoundEvent = failSound.GetComponent<EventBehavior>();
    }

    IEnumerator waitInfosToEnd() {
        if (soundInfoEvent != null && textInfoEvent != null) {
            if(textInfoEvent.isFinished && soundInfoEvent.isFinished) {
                infosFinished = true;
            }
        } else if (soundInfoEvent != null) {
            if(soundInfoEvent.isFinished) {
                infosFinished = true;
            }
        } else if (textInfo != null) {
            if(textInfoEvent.isFinished) {
                infosFinished = true;
            }
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator waitConditionToEnd() {
        if (exitEventEvent.fail) {
            // Play fail text
            if (failText != null) {
                Instantiate(failText);
            }

            // Play fail sound
            if (failSound != null) {
                Instantiate(failSound);
            }

            if (failText != null && failSound != null) {
                if (failTextEvent.isFinished && failSoundEvent.isFinished) {
                    exitEventEvent.fail = false;
                }
            }
            else if (failSound != null) {
                if (soundInfoEvent.isFinished) {
                    exitEventEvent.fail = false;
                }
            }
            else if (textInfo != null) {
                if (failTextEvent.isFinished) {
                    exitEventEvent.fail = false;
                }
            }
        }
        else if (exitEventEvent.success) {
            // Play successEvent
            if (successText != null) {
                Instantiate(successText);
            }

            if (successSound != null) {
                Instantiate(successSound);
            }

            isFinished = true;
        }
        yield return new WaitForEndOfFrame();
    }
	
	void Update () {
        // If we didn't played the infos part
        if(!infosFinished) {
            // If the event 
            if(!infosCoroutineLaunched) {
                // Play textInfo and/or soundInfo
                if (soundInfoEvent != null && textInfoEvent != null) {
                    if (!textInfoEvent.isFinished && !soundInfoEvent.isFinished) {
                        Instantiate(textInfoEvent);
                        Instantiate(soundInfoEvent);
                    }
                }
                else if (soundInfoEvent != null) {
                    if (!soundInfoEvent.isFinished) {
                        Instantiate(soundInfoEvent);
                    }
                }
                else if (textInfo != null) {
                    if (!textInfoEvent.isFinished) {
                        Instantiate(textInfoEvent);
                    }
                }

                // Wait for it / them to end
                StartCoroutine("waitInfosToEnd");
                infosCoroutineLaunched = true;
            }
        } else {
            // If the event doesn't exist
            if(!conditionCoroutineLaunched) {
                // Instantiate the event
                Instantiate(exitEventEvent);
                // Launch coroutine that wait for it to end
                StartCoroutine("waitConditionToEnd");
                conditionCoroutineLaunched = true;
            }
        }
	}
}
