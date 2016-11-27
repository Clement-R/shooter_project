using UnityEngine;
using System.Collections;

    public class GameManager_GameRules_master : MonoBehaviour {
        bool gameLost = false;


        public int lifeInit;
        public int levelLife = 4; //Vie du monde

        private int life;


        void Start() {
            life = lifeInit;
        }

        void Update() {
            if (life < 0 || gameLost) {
                Time.timeScale = 0.0f;
            }
        }

        public void loose() {
            this.gameLost = true;
        }

        public void ennemyShot() {

        }

        public void playerTouched() {
            life--;
            Debug.Log("Vie restante : " + life);
        }

        public void ennemyPassed() {
            levelLife--;
        }

    }