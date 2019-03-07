using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    float distance = 5f;
    private float jumpForce = 2f;
    int maxHeight = 5;
    private bool isGrounded = true;
    private Rigidbody pRigidBody;
    public AudioSource tick;
    public GameObject door;
    // Use this for initialization
    void Start ()
    {
        pRigidBody = GetComponent<Rigidbody>();
        tick = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position = transform.position + Camera.main.transform.forward * distance * (Time.deltaTime * 2);
        Jump();
    }

    public void Jump()
    {
        if(Input.GetButton("Jump"))
        {
            if(isGrounded == true)
            {
                transform.position += Vector3.up * 200f * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.CompareTag("Plane"))
        {
            Debug.Log("Entered");
            isGrounded = true;
            pRigidBody.AddForce(new Vector3(0, jumpForce, 0));
        }

        if (theCollision.gameObject.CompareTag("Plane"))
        {
            tick.Play();
            Debug.Log("Sound work");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            Debug.Log("Exited");
            isGrounded = false;
        }
    }

    void OnMouseOver(Collision collision)
    {
        if(Input.GetMouseButtonDown(0))
        {
            door.transform.Rotate(0, 90, 0);
            Debug.Log("DoorWork");
        }
    }
}
