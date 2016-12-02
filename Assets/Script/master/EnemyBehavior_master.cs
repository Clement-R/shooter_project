using UnityEngine;
using System.Collections;

public class EnemyBehavior_master : MonoBehaviour {
    public GameObject deathSound;

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
        Destroy(this.gameObject, 24.0f);
        god = GameObject.Find("GameManager_master").GetComponent<GameManager_GameRules_master>();
    }

    void Update()
    {
        if (this.isTargeted)
        {
            if (!effectLaunched)
            {
                effectLaunched = true;
                StartCoroutine("effect");
            }
        }
        else
        {
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
        // Play sound
        GameObject deathSoundEmitter = Instantiate(deathSound);
        deathSoundEmitter.transform.position = gameObject.transform.position;

        // Push information to the game manager
        GameObject.Find("GameManager").GetComponent<GameManager_WaveSpawner>().numberOfEnemiesKilled++;
        god.ennemyShot();

        // Destroy game object
        Destroy(this.gameObject);

        // Stop sound
        AkSoundEngine.StopPlayingID(eventIdIndic);
        AkSoundEngine.StopPlayingID(eventIdOn);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "southWall")
        {
            god.ennemyPassed();
            Destroy(this.gameObject);
        }
        else if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Touche le joueur");
            god.playerTouched();
            Destroy(this.gameObject);
        }
    }
}
