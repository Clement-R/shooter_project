using UnityEngine;
using System.Collections;

public class turretShooter_master : MonoBehaviour {

    public GameObject projectile;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    void Update()
    {
        if (Input.GetButton("Fire_1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectile, transform.FindChild("pivotScope").position, transform.FindChild("pivotScope").rotation);
        }
    }
}
