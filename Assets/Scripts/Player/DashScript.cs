using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    Rigidbody2D player_rigidbody2D;
    DoublePress doublePress_Script;
    GroundedScript grounded_Script;
    MovementScript movement_Script;

    int dash_Strength = 10;
    bool dash_State;
    float dash_Dur = 0.5f;
    float dash_Counter;

    int def_GravityScale = 2;
    int def_LinearDrag = 0;
    int custom_LinearDrag = 2;

    // Start is called before the first frame update
    void Start()
    {
        dash_State = false;

        doublePress_Script = GetComponent<DoublePress>();
        player_rigidbody2D = GetComponent<Rigidbody2D>();
        grounded_Script = GetComponentInChildren<GroundedScript>();
        movement_Script = GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log();

        if (doublePress_Script.doubePress_Right_aerial == true && dash_State == false && grounded_Script.isGrounded == false) //Aerial Dash RIGHT
        {
            movement_Script.enabled = false;                //locks player movement
            doublePress_Script.enabled = false;             //locks additional double pressing inputs
            dash_State = true;                              //start of dash_State 
            dash_Counter = dash_Dur;                        //begins dash countdown 

            player_rigidbody2D.gravityScale = 0;            //removes gravity for player 
            player_rigidbody2D.drag = custom_LinearDrag;    //increases friction so player wont slip on the floor 

            //player_rigidbody2D.AddForce(Vector2.right * dash_Strength, ForceMode2D.Impulse);
            player_rigidbody2D.velocity = Vector2.right * dash_Strength;    //dash movement itself
            doublePress_Script.doubePress_Right_aerial = false;             //resets double press input for right_Aerial
        }

        if (doublePress_Script.doubePress_Left_aerial == true && dash_State == false && grounded_Script.isGrounded == false) //Aerial Dash RIGHT
        {
            movement_Script.enabled = false;
            doublePress_Script.enabled = false;
            dash_State = true;
            dash_Counter = dash_Dur;

            player_rigidbody2D.gravityScale = 0;
            player_rigidbody2D.drag = custom_LinearDrag;

            //player_rigidbody2D.AddForce(Vector2.right * dash_Strength, ForceMode2D.Impulse);
            player_rigidbody2D.velocity = Vector2.left * dash_Strength;
            doublePress_Script.doubePress_Left_aerial = false;
        }

        if (dash_State == true)                             //checks if a dash state has started
        {
            dash_Counter -= Time.deltaTime;                 //dash state countdown

            if (dash_Counter <= 0)                          //once countdown reaches zero, times up
            {
                player_rigidbody2D.gravityScale = def_GravityScale;     //returns gravity 
                player_rigidbody2D.drag = def_LinearDrag;               //returns default friction
            }

            if (grounded_Script.isGrounded == true)                     //once player hits the floor,
            {
                dash_State = false;                                     //end of dash state
                movement_Script.enabled = true;                         //unlocks movement
                doublePress_Script.enabled = true;                      //unlocks double pressing inputs
            }
        }


    }
    //Should actually be AERIALdashscript.
    /*Accesses the DoublePressScript to see whether or not an input is valid. When it is valid, it also has access to the GroundedScript to check 
    whether or not player is grounded. If both conditons are true, then the player is able to dash. This script accesses the rigidbody2D to move
    the player as a "dash". */
}
