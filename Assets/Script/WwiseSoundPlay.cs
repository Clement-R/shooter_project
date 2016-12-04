using UnityEngine;
using System.Collections;

public class WwiseSoundPlay : MonoBehaviour {
    public string soundIndex = "";

    private EventBehavior eventBehavior;

    void Start () {
        if(soundIndex != "") {
            AkSoundEngine.PostEvent(soundIndex, gameObject, (uint)AkCallbackType.AK_EndOfEvent, OnSoundEnd, null);
        }

        eventBehavior = GetComponent<EventBehavior>();
    }

	void OnSoundEnd(object in_cookie, AkCallbackType in_type, object in_info) {
        if (in_type == AkCallbackType.AK_EndOfEvent) {
			Debug.Log ("Sound end");
            eventBehavior.isFinished = true;
        }
    }
}
