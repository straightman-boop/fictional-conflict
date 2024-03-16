using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedScript : MonoBehaviour
{
    [HideInInspector] public bool isGrounded;

    MovementScript movement_Script;

    float lock_Time = 0.2f;
    float lock_Counter;
    bool lock_Locked;

    private void Start()
    {
        lock_Locked = false;

        movement_Script = GetComponentInParent<MovementScript>();
    }


    private void Update()
    {
        if (isGrounded == false && lock_Locked == false)
        {
            lock_Counter -= Time.deltaTime;

            if(lock_Counter <= 0)
            {
                movement_Script.enabled = false;
            }

        }
    }

    //When using FixedJoint2D Component, the Automatic Configure Connection automatically simulates the offset
    //in the worldspace. Uncheck it if offset betwen colliders is buggy.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            movement_Script.enabled = true;
            isGrounded = true;
            //Debug.Log("isGrounded: " + isGrounded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            lock_Counter = lock_Time;
            isGrounded = false;
            //Debug.Log("isGrounded: " + isGrounded);
        }
    }

}
