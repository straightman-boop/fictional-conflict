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
            movement_Script.enabled = false;
            doublePress_Script.enabled = false;
            dash_State = true;
            dash_Counter = dash_Dur;

            player_rigidbody2D.gravityScale = 0;
            player_rigidbody2D.drag = custom_LinearDrag;
            
            //player_rigidbody2D.AddForce(Vector2.right * dash_Strength, ForceMode2D.Impulse);
            player_rigidbody2D.velocity = Vector2.right * dash_Strength;
            doublePress_Script.doubePress_Right_aerial = false;
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

        if (dash_State == true)
        {
            dash_Counter -= Time.deltaTime;

            if (dash_Counter <= 0)
            {
                player_rigidbody2D.gravityScale = def_GravityScale;
                player_rigidbody2D.drag = def_LinearDrag;
            }

            if (grounded_Script.isGrounded == true)
            {
                dash_State = false;
                movement_Script.enabled = true;
                doublePress_Script.enabled = true;
            }
        }


    }
}
