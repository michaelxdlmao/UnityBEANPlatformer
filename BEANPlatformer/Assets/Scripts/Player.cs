﻿using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    public float speed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponet;
    private bool isGrounded;
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask = 0;
    private int superJumpsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if space key is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    //FixedUpdate is called once every physics update
    private void FixedUpdate()
    {
            
       

            
        rigidbodyComponet.velocity = new Vector3(horizontalInput * speed, rigidbodyComponet.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }



        if (jumpKeyWasPressed)
        {
            float jumpPower = 5f;
            if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }
            rigidbodyComponet.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;

        }

    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }
    





}

    

