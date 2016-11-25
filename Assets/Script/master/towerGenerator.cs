using UnityEngine;
using System.Collections;

public class towerGenerator : MonoBehaviour {

    public Sprite[] towerLevel1;
    public Sprite[] towerLevel2;
    public Sprite[] towerLevel3;
    public Sprite[] towerLevel4;
    public Sprite[] towerLevel5;
    public float yRespawn;
    public float scrollSpeed;

    private bool respawning = false;
    private Vector3 respawnTransform;

    // Use this for initialization
    void Start () {

        respawnTransform = new Vector3(gameObject.transform.position.x, yRespawn, 0);
        Sprite[] sprites = getTowerLevel();
        Sprite sprite;
        int alea = Random.Range(0, 1);
        if (alea == 0)
        {
            sprite = sprites[Random.Range(0, sprites.Length)];
        } else
        {
            sprite = null;
        }
        GetComponent<SpriteRenderer>().sprite = sprite;

    }
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.up * scrollSpeed * -1;
            
	
	}

    Sprite [] getTowerLevel()
    {
        switch (GameObject.Find("GameManager").GetComponent<GameManager_GameRules>().levelLife)
        {
            case 4:  return towerLevel5;
            case 3:  return towerLevel4;
            case 2:  return towerLevel3;
            case 1:  return towerLevel2;
            case 0:  return towerLevel1;
            default:
                Debug.Log("!!! Passage par la case default dans towerGenerator");
                return null;
        }
    }

    void OnBecameInvisible()
    {
        //Affecte un sprite aléatoirement, en fonction des vies restantes au monde
        Sprite[] sprites = getTowerLevel();
        Sprite sprite;
        int alea = Random.Range(0, 1);
        if (alea == 0)
        {
            sprite = sprites[Random.Range(0, sprites.Length)];
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            sprite = null;
        }
        
        transform.localPosition = respawnTransform;
    }
}
