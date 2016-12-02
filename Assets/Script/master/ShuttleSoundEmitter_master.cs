﻿using UnityEngine;
using System.Collections;

public class ShuttleSoundEmitter_master : MonoBehaviour {
    // Public
    public float minimumDetectionRange;
    public float cooldownBeforeNextTargeting = 0.2F;

    // Public but not visible
    [HideInInspector]
    public GameObject spawnOnLeftClick;

    // Private
    private GameObject targetedEnemy = null;
    private ShuttleBehavior_master behavior;
    private float closestDistance = 1000.0f;
    private float nextFire = 0.0F;

    void Start()
    {
        behavior = this.GetComponent<ShuttleBehavior_master>();
    }

    void Update()
    {
        if (Input.GetButton("Fire_1") && !behavior.isStuned && Time.time > nextFire)
        {
            
            nextFire = Time.time + cooldownBeforeNextTargeting;

            // Unmark last enemy if needed
            if (targetedEnemy != null)
            {
                targetedEnemy.GetComponent<EnemyBehavior_master>().isTargeted = false;
                targetedEnemy = null;
                closestDistance = 1000.0f;
            }

            // Find all enemies
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemy in enemies)
            {
                // Calculate distance between Fennec and the enemy
                float distance = Vector2.Distance(this.transform.position, enemy.transform.position);

                // Keep the enemy if the distance is inferior than the saved distance
                if (distance < closestDistance && distance < minimumDetectionRange)
                {
                    closestDistance = distance;
                    targetedEnemy = enemy;
                }
            }

            // Mark closest enemy
            if (targetedEnemy != null)
            {
                targetedEnemy.GetComponent<EnemyBehavior_master>().isTargeted = true;
            }

            // Play sound effect
            // GameObject explosion = Instantiate(spawnOnLeftClick);
            // explosion.transform.position = gameObject.transform.position;
        }
    }
}
