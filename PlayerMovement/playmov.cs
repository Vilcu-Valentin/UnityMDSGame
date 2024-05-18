using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    public bool grounded = false;
    public float groundCheckDistance;
    private float bufferCheckDistance = 0.1f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
    
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        groundCheckDistance=(GetComponent<CapsuleCollider>().height/2)+bufferCheckDistance;

        if(Input.GetKeyDown(KeyCode.Space)&&grounded){
            GetComponent<Rigidbody>().AddForce(transform.up * 3,ForceMode.Impulse);
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up,out hit,groundCheckDistance)){
            grounded=true;
        } else
        {
            grounded=false;
        }
    }
        
}