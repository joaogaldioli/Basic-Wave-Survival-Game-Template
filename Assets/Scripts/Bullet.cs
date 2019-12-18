using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;
    public float damage = 2f;

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        if (rb.position.x > 26 || rb.position.x < -26 || rb.position.z > 26 || rb.position.z < -26)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().health -= damage;
            if (other.gameObject.GetComponent<Enemy>().health <= 0.0)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
    }

}
