using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    Rigidbody2D player_rigidbody2D;
    DoublePress doublePress_Script;
    GroundedScript grounded_Script;
    MovementScript movement_Script;

    int run_Speed = 5;

    int dash_Strength = 10;
    bool dash_State;
    float dash_Dur = 0.5f;
    float dash_Counter;

    int def_GravityScale = 2;

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
        if (doublePress_Script.doubePress_Right == true && dash_State == false && grounded_Script.isGrounded == false) //Aerial Dash RIGHT
        {
            movement_Script.enabled = false;
            dash_State = true;
            dash_Counter = dash_Dur;

            player_rigidbody2D.gravityScale = 0;
            //player_rigidbody2D.AddForce(Vector2.right * dash_Strength, ForceMode2D.Impulse);
            player_rigidbody2D.velocity = Vector2.right * dash_Strength;
            doublePress_Script.doubePress_Right = false;
        }

        if (doublePress_Script.doubePress_Left == true && dash_State == false && grounded_Script.isGrounded == false) //Aerial Dash RIGHT
        {
            movement_Script.enabled = false;
            dash_State = true;
            dash_Counter = dash_Dur;

            player_rigidbody2D.gravityScale = 0;
            //player_rigidbody2D.AddForce(Vector2.right * dash_Strength, ForceMode2D.Impulse);
            player_rigidbody2D.velocity = Vector2.left * dash_Strength;
            doublePress_Script.doubePress_Left = false;
        }

        if (doublePress_Script.doubePress_Right == true && dash_State == false && grounded_Script.isGrounded == true) //Grounded Dash RIGHT
        {
            //name this Grounded Sprint instead; Put it in a new script;
        }


        if (dash_State == true)
        {
            dash_Counter -= Time.deltaTime;

            if (dash_Counter <= 0)
            {            
                player_rigidbody2D.gravityScale = def_GravityScale;
            }

            if(grounded_Script.isGrounded == true)
            {
                dash_State = false;
                movement_Script.enabled = true;
            }
        }


    }
}
