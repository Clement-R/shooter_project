using UnityEngine;
using System.Collections;

public class TrashBehavior_master : MonoBehaviour {

    public GameObject deathSound;
    public Transform balise;

    public bool isTargeted = false;
    public bool isFocused = false;

    public float normalVolume = 0.2f;
    public float focusedVolume = 0.4f;

    private GameManager_GameRules_master god;
    private bool effectLaunched = false;
    private bool soundIsPlaying = false;
    private uint eventIdIndic = 0;
    private uint eventIdOn = 0;

    void Start()
    {
        god = GameObject.Find("GameManager_master").GetComponent<GameManager_GameRules_master>();
        GetComponent<Animator>().speed = 0;
        
    }

    void Update()
    {
        if (this.isTargeted)
        {
            if (!effectLaunched)
            {
                GameObject baliseInstance = (GameObject)Instantiate(balise.gameObject, transform);
                baliseInstance.transform.localPosition = new Vector3(0, 20f, 0);
                effectLaunched = true;
                StartCoroutine("effect");
            }
        }
        else
        {
            if (transform.childCount > 0)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            effectLaunched = false;
            StopCoroutine("effect");
        }

        // Play chord when the scope is over the enemy
        if (isTargeted && isFocused && eventIdOn == 0)
        {
            Debug.Log("PlaySound");
            eventIdOn = AkSoundEngine.PostEvent("chord", gameObject, (uint)AkCallbackType.AK_EndOfEvent, MyCallbackFunction, null);
        }
    }

    void LateUpdate()
    {
        isFocused = false;
    }

    public IEnumerator effect()
    {

        if (eventIdIndic == 0)
        {
            eventIdIndic = AkSoundEngine.PostEvent("indic", gameObject);
        }

        yield return new WaitForSeconds(0.5f);
        StartCoroutine("effect");
    }

    void MyCallbackFunction(object in_cookie, AkCallbackType in_type, object in_info)
    {
        Debug.Log("SoundEnd");
        if (in_type == AkCallbackType.AK_EndOfEvent)
        {
            Debug.Log("SoundEnd");
            eventIdOn = 0;
        }
    }

    public void Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().speed = 5;
        GameObject.Find("GameManager_master").GetComponent<GameManager_WaveSpawner_master>().numberOfEnemiesKilled++;
        isTargeted = false;

        // Play sound
        GameObject deathSoundEmitter = Instantiate(deathSound);
        deathSoundEmitter.transform.position = gameObject.transform.position;


        Destroy(this.gameObject, 1f);

        // Stop sound
        AkSoundEngine.StopPlayingID(eventIdIndic);
        AkSoundEngine.StopPlayingID(eventIdOn);
    }

    void OnTriggerEnter2D(Collider2D coll) { 
        if(coll.gameObject.tag == "southWall")
        {
            Die();
        }
    }
}
