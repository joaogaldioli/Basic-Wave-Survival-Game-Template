using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxHealth = 6f;
    public float health;
    public float damage = 1f;
    public GameObject player;
    private Rigidbody rb;
    public float movementSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");

        //rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        transform.LookAt(player.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        //Vector3 direction = player.transform.position - transform.position;
        //float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().playerHealth -= damage;
            if(other.gameObject.GetComponent<PlayerMovement>().playerHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
