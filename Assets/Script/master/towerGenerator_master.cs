using UnityEngine;
using System.Collections;

public class towerGenerator_master : MonoBehaviour {

    public Sprite[] towerLevel1;
    public Sprite[] towerLevel2;
    public Sprite[] towerLevel3;
    public Sprite[] towerLevel4;
    public Sprite[] towerLevel5;
    public float yDisappear;
    public float yRespawn;
    public float scaleMin;
    public float scaleMax;
    public float scrollSpeed;
    
    private Vector3 respawnTransform;

    void Start () {        
        respawnTransform = new Vector3(gameObject.transform.position.x, yRespawn, 0);
        randomSprite();
        randomSize();
    }
	
	void Update () {
        transform.position += Vector3.up * scrollSpeed * -1 * Time.deltaTime;
        //Detecte s'il doit réaparaître
        if (transform.position.y < yDisappear)
        {
            randomSprite();
            randomSize();
            transform.position = respawnTransform;
        }
    }

    void randomSize()
    {
        float randScale = Random.Range(scaleMin, scaleMax);
        transform.localScale = new Vector3(randScale, randScale, 1);
    }

    void randomSprite()
    {
        //Affecte un sprite aléatoirement, en fonction des vies restantes au monde
        Sprite[] sprites = getTowerLevel();
        Sprite sprite;
        int alea = Random.Range(0, 1); //A une chance sur deux ne pas apparaitre
        if (alea == 0)
        {
            sprite = sprites[Random.Range(0, sprites.Length)];
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else
        {

            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    Sprite [] getTowerLevel()
    {
        if (GameObject.Find("GameManager_master"))
        {
            switch (GameObject.Find("GameManager_master").GetComponent<GameManager_GameRules_master>().levelLife)
            {
                case 4: return towerLevel5;
                case 3: return towerLevel4;
                case 2: return towerLevel3;
                case 1: return towerLevel2;
                case 0: return towerLevel1;
                default:
                    return towerLevel1;
            }
        }
        return null;
    }
    
}
