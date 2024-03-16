using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedScript : MonoBehaviour
{
    [HideInInspector] public bool isGrounded;

    //When using FixedJoint2D Component, the Automatic Configure Connection automatically simulates the offset
    //in the worldspace. Uncheck it if offset betwen colliders is buggy.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            isGrounded = true;
            //Debug.Log("isGrounded: " + isGrounded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            isGrounded = false;
            //Debug.Log("isGrounded: " + isGrounded);
        }
    }

}
