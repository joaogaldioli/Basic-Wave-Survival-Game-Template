using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float rotSpeed;
    public float maxHealth = 10f;
    public float playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        rotSpeed = 70f;
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (transform.position.x >= 24.5)
        {
            Vector3 newPosition = new Vector3(24.5f, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
        if (transform.position.x <= -24.5)
        {
            Vector3 newPosition = new Vector3(-24.5f, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
        if (transform.position.z >= 24.5)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, 24.5f);
            transform.position = newPosition;
        }
        if (transform.position.z <= -24.5)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, -24.5f);
            transform.position = newPosition;
        }
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            }

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
            }
        }
    }
    
}

