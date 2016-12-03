using UnityEngine;
using System.Collections;

public class turretShooter_master : MonoBehaviour {
    // Public
    public float fireRate = 0.5F;

    // Public but not visible
    [HideInInspector]
    public GameObject projectile;

    // Private
    private float nextFire = 0.0F;

    void Update()
    {
        if (( Input.GetButton("Fire_2") || Input.GetButton("Fire_3") || Input.GetButton("Fire_4") || Input.GetButton("Fire_5")) && Time.time > nextFire)
        {
            transform.FindChild("pivotEventail").FindChild("eventail").GetComponent<Animator>().SetBool("playAnimation", true);
            nextFire = Time.time + fireRate;
            Instantiate(projectile, transform.FindChild("pivotEventail").position, transform.FindChild("pivotEventail").rotation);
        }
    }

}
