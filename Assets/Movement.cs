using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody rb; //reference to the rigidbody component called 'rb'
    public float jumpForce = 5000f;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float canJump = 0f;

    private void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); // add a forward force, deltatime to help fps weirdness

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
       
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canJump)
        {
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            canJump = Time.time + 1.5f; // canJump = 1.5f so there is a delay on jump (no flying)
        }
   
    }
}
