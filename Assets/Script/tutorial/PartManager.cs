using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartManager : MonoBehaviour {
    public bool isFinished = false;

    public GameObject textInfo;
    public string text;
    public float remainTime = 1.0f;

    public GameObject soundInfo;
    public string soundIndex;

    // Exit event related
    public GameObject exitEvent;

    public GameObject successText;
    public string successTextContent;
    public float successTextRemainTime = 1.0f;
    public GameObject failText;
    public string failTextContent;
    public float failTextRemainTime = 1.0f;

    public GameObject successSound;
    public GameObject failSound;

    // Start informations related
    private GameObject textInfoInstance;
    private EventBehavior textInfoEvent = null;
    private GameObject soundInfoInstance;
    private EventBehavior soundInfoEvent = null;

    // Exit condition related
    private GameObject exitEventInstance = null;
    private EventBehavior exitEventEvent = null;
    private EventBehavior successTextEvent = null;
    private EventBehavior successSoundEvent = null;
    private EventBehavior failTextEvent = null;
    private EventBehavior failSoundEvent = null;

    private bool infosCoroutineLaunched = false;
    private bool infosFinished = false;
    private bool conditionCoroutineLaunched = false;
    
    IEnumerator waitInfosToEnd() {
        if (soundInfoEvent != null && textInfoEvent != null) {
            if (textInfoEvent.isFinished && soundInfoEvent.isFinished) {
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
        if(!infosFinished) {
            StartCoroutine("waitInfosToEnd");
        }
    }

    IEnumerator waitConditionToEnd() {
        if (exitEventEvent.fail) {
            // Play fail text
            if (failText != null) {
                failTextEvent = Instantiate(failText).GetComponent<EventBehavior>();
                TextDisplay textManager = failTextEvent.GetComponentInChildren<TextDisplay>();
                textManager.remainTime = this.failTextRemainTime;
            }

            // Play fail sound
            if (failSound != null) {
                failSoundEvent = Instantiate(failSound).GetComponent<EventBehavior>();
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
            // Play success text
            if (successText != null) {
                successTextEvent = Instantiate(successText).GetComponent<EventBehavior>();
                TextDisplay textManager = successTextEvent.GetComponentInChildren<TextDisplay>();
                textManager.remainTime = this.successTextRemainTime;
            }

            // Play success sound
            if (successSound != null) {
                successSoundEvent = Instantiate(successSound).GetComponent<EventBehavior>();
            }

            isFinished = true;
        }
        yield return new WaitForEndOfFrame();
        StartCoroutine("waitConditionToEnd");
    }
	
	void Update () {
        // If we didn't played the infos part
        if(!infosFinished) {
            // If the event
            if(!infosCoroutineLaunched) {
                // Play textInfo and/or soundInfo
                if (soundInfo != null && textInfo != null) {
                    textInfoInstance = Instantiate(textInfo, transform) as GameObject;
                    soundInfoInstance = Instantiate(soundInfo, transform) as GameObject;
                    
                    textInfoEvent = textInfoInstance.GetComponent<EventBehavior>();
                    Text widgetText = textInfoInstance.GetComponentInChildren<Text>();
                    widgetText.text = this.text;
                    TextDisplay textManager = textInfoInstance.GetComponentInChildren<TextDisplay>();
                    textManager.remainTime = this.remainTime;

                    soundInfoEvent = soundInfoInstance.GetComponent<EventBehavior>();
                    WwiseSoundPlay soundPlayer = soundInfoInstance.GetComponent<WwiseSoundPlay>();
                    soundPlayer.soundIndex = this.soundIndex;
                }
                else if (soundInfo != null) {
                    soundInfoInstance = Instantiate(soundInfo, transform) as GameObject;

                    soundInfoEvent = soundInfoInstance.GetComponent<EventBehavior>();
                    WwiseSoundPlay soundPlayer = soundInfoInstance.GetComponent<WwiseSoundPlay>();
                    soundPlayer.soundIndex = this.soundIndex;
                }
                else if (textInfo != null) {
                    textInfoInstance = Instantiate(textInfo, transform) as GameObject;

                    textInfoEvent = textInfoInstance.GetComponent<EventBehavior>();
                    Text widgetText = textInfoInstance.GetComponentInChildren<Text>();
                    widgetText.text = this.text;
                    TextDisplay textManager = textInfoInstance.GetComponentInChildren<TextDisplay>();
                    textManager.remainTime = this.remainTime;
                }

                // Wait for it / them to end
                StartCoroutine("waitInfosToEnd");
                infosCoroutineLaunched = true;
            }
        } else {
            if (exitEvent != null) {
                // If an exit event exist and is not already running
                if (!conditionCoroutineLaunched) {
                    // Instantiate the event
                    exitEventInstance = Instantiate(exitEvent) as GameObject;

                    // Get all necessary informations
                    exitEventEvent = exitEventInstance.GetComponent<EventBehavior>();

                    /*
                    if (successText != null) {
                        successTextEvent = successText.GetComponent<EventBehavior>();
                    }
                    if (successSound != null) {
                        successSoundEvent = successSound.GetComponent<EventBehavior>();
                    }
                    if (failText != null) {
                        failTextEvent = failText.GetComponent<EventBehavior>();
                    }
                    if (failSound != null) {
                        failSoundEvent = failSound.GetComponent<EventBehavior>();
                    }
                    */

                    // Launch coroutine that wait for it to end
                    StartCoroutine("waitConditionToEnd");
                    conditionCoroutineLaunched = true;
                }
            } else {
                isFinished = true;
            }
        }
	}
}
