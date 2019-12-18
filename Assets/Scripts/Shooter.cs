using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 5f;
    public float fireRate = 0.5f;
    private float lastShot = 0.0f;
    
   
    

    // Update is called once per frame
    void Update()
    {
        shoot();
    }
    void shoot()
    {
        //if enemy count is over 1 then 
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        int n = allEnemies.Length;

        if (n > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (Time.time > fireRate + lastShot)
                {
                    Vector3 pos = transform.position;
                    GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation);
                    //Rigidbody instBulletRigid = instBullet.GetComponent<Rigidbody>();
                    //instBulletRigid.AddForce(transform.forward * speed);
                    //instBulletRigid.velocity = transform.forward * speed;
                    lastShot = Time.time;
                }
            }
        }

    }
}
