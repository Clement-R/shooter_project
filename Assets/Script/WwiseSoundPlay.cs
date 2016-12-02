using UnityEngine;
using System.Collections;

public class WwiseSoundPlay : MonoBehaviour {
    public string soundIndex = "";

    private uint eventId = 0;

	void Start () {
        if(soundIndex != "") {
            eventId = AkSoundEngine.PostEvent(soundIndex, gameObject, (uint)AkCallbackType.AK_EndOfEvent, OnSoundEnd, null);
        }
    }

	void OnSoundEnd(object in_cookie, AkCallbackType in_type, object in_info) {
        if (in_type == AkCallbackType.AK_EndOfEvent) {
            eventId = 0;
        }
    }
}
