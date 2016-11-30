﻿using UnityEngine;
using System.Collections;

public class turretShooter_master : MonoBehaviour {

    public GameObject projectile;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    

    void Update()
    {
        if ( (Input.GetButton("Fire_2") || /*juste pour test au clavier*/Input.GetButton("Fire3")) && Time.time > nextFire)
        {
            transform.FindChild("eventail").GetComponent<Animator>().SetBool("playAnimation", true);
            nextFire = Time.time + fireRate;
            Instantiate(projectile, transform.FindChild("pivotScope").position, transform.FindChild("pivotScope").rotation);
        }
    }

}
