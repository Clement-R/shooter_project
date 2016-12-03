using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartManager : MonoBehaviour {
    public bool isFinished = false;

    public GameObject textInfo;
    public string text = "";
    public float remainTime = 1.0f;

    public GameObject soundInfo;
    public string soundIndex = "";

    // Exit event related
    public GameObject exitEvent;

    public GameObject successText;
    public string successTextContent;
    public float successTextRemainTime = 1.0f;

    public GameObject failText;
    public string failTextContent = "";
    public float failTextRemainTime = 1.0f;

    public GameObject successSound;
    public string successSoundIndex = "";
    public GameObject failSound;
    public string failSoundIndex = "";

    // Start informations related
    private GameObject textInfoInstance;
    private EventBehavior textInfoEvent = null;
    private GameObject soundInfoInstance;
    private EventBehavior soundInfoEvent = null;

    // Exit condition related
    private GameObject exitEventInstance = null;
    private EventBehavior exitEventEvent = null;

    private GameObject successTextInstance = null;
    private EventBehavior successTextEvent = null;

    private GameObject successSoundInstance = null;
    private EventBehavior successSoundEvent = null;

    private GameObject failTextInstance = null;
    private EventBehavior failTextEvent = null;

    private GameObject failSoundInstance = null;
    private EventBehavior failSoundEvent = null;

    // Conditions bool
    private bool infosCoroutineLaunched = false;
    private bool infosFinished = false;
    private bool conditionCoroutineLaunched = false;
    
    IEnumerator waitInfosToEnd() {
        if (soundInfoEvent != null && textInfoEvent != null) {
            if (textInfoEvent.isFinished && soundInfoEvent.isFinished) {
                Destroy(textInfoInstance);
                Destroy(soundInfoInstance);
                infosFinished = true;
            }
        } else if (soundInfoEvent != null) {
            if(soundInfoEvent.isFinished) {
                Destroy(soundInfoInstance);
                infosFinished = true;
            }
        } else if (textInfo != null) {
            if (textInfoEvent.isFinished) {
                Destroy(textInfoInstance);
                infosFinished = true;
            }
        }
        
        if(!infosFinished) {
            yield return new WaitForEndOfFrame();
            StartCoroutine("waitInfosToEnd");
        } else {
            yield break;
        }
    }

    IEnumerator waitConditionToEnd() {
        if (exitEventEvent.fail) {
            // Play fail text
            if (failTextContent != "") {
                if (failTextInstance == null) {
                    failTextInstance = Instantiate(failText);
                    Text widgetText = failTextInstance.GetComponentInChildren<Text>();
                    widgetText.text = this.failTextContent;
                    failTextEvent = failTextInstance.GetComponent<EventBehavior>();
                    TextDisplay textManager = failTextEvent.GetComponentInChildren<TextDisplay>();
                    textManager.remainTime = this.failTextRemainTime;
                }
            }
            
            // Play fail sound
            if (failSoundIndex != "") {
                if(failSoundInstance == null) {
                    failSoundInstance = Instantiate(failText);
                    failSoundEvent = failSoundInstance.GetComponent<EventBehavior>();
                }
            }

            if (failTextContent != "" && failSoundIndex != "") {
                if (failTextEvent.isFinished && failSoundEvent.isFinished) {
                    Destroy(failTextInstance);
                    Destroy(failSoundInstance);
                    exitEventEvent.fail = false;
                }
            } else if (failSoundIndex != "") {
                if (soundInfoEvent.isFinished) {
                    Destroy(failSoundInstance);
                    exitEventEvent.fail = false;
                }
            } else if (failTextContent != "") {
                if (failTextEvent.isFinished) {
                    Destroy(failTextInstance);
                    exitEventEvent.fail = false;
                }
            }
        }
        else if (exitEventEvent.success) {
            // Play success text
            if (successTextContent != "") {
                if(successTextInstance == null) {
                    successTextInstance = Instantiate(successText, transform) as GameObject;
                    Text widgetText = successTextInstance.GetComponentInChildren<Text>();
                    widgetText.text = this.successTextContent;
                    successTextEvent = successTextInstance.GetComponent<EventBehavior>();
                    TextDisplay textManager = successTextEvent.GetComponentInChildren<TextDisplay>();
                    textManager.remainTime = this.successTextRemainTime;
                }
            }

            // Play success sound
            if (successSoundIndex != "") {
                if(successSoundInstance == null) {
                    successSoundInstance = Instantiate(successSound, transform) as GameObject;
                    successSoundEvent = successSoundInstance.GetComponent<EventBehavior>();
                }
            }
            
            if (successTextContent != "" && successSoundIndex != "") {
                if (successTextEvent.isFinished && successSoundEvent.isFinished) {
                    Destroy(successTextInstance);
                    Destroy(successSoundInstance);
                    isFinished = true;
                }
            } else if (successSoundIndex != "") {
                if (successSoundEvent.isFinished) {
                    Destroy(successSoundInstance);
                    isFinished = true;
                }
            } else if (successTextContent != "") {
                if (successTextEvent.isFinished) {
                    Destroy(successTextInstance);
                    isFinished = true;
                }
            }
        }
        
        if(!isFinished) {
            yield return new WaitForEndOfFrame();
            StartCoroutine("waitConditionToEnd");
        } else {
            yield break;
        }
    }
	
	void Update () {
        // If we didn't played the infos part
        if(!infosFinished) {
            // If the event
            if(!infosCoroutineLaunched) {
                // Play textInfo and/or soundInfo
                if (soundIndex != "" && text != "") {
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
                else if (soundIndex != "") {
                    soundInfoInstance = Instantiate(soundInfo, transform) as GameObject;

                    soundInfoEvent = soundInfoInstance.GetComponent<EventBehavior>();
                    WwiseSoundPlay soundPlayer = soundInfoInstance.GetComponent<WwiseSoundPlay>();
                    soundPlayer.soundIndex = this.soundIndex;
                }
                else if (text != "") {
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
                    exitEventInstance = Instantiate(exitEvent, transform) as GameObject;
                    exitEventEvent = exitEventInstance.GetComponent<EventBehavior>();

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
