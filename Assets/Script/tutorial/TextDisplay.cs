using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour {
    [HideInInspector]
    public float remainTime = 1.0f;

    private EventBehavior eventBehavior;

    void Start() {
        StartCoroutine("checkForRemainingTime");
        eventBehavior = GetComponent<EventBehavior>();
    }

    IEnumerator checkForRemainingTime() {
        yield return new WaitForSeconds(remainTime);
        eventBehavior.isFinished = true;
    }
}
