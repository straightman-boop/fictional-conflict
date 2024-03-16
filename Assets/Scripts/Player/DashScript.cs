using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    Rigidbody2D player_rigidbody2D;
    DoublePress doublePress_Script;

    int dash_Strength = 5;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (doublePress_Script.doubePress_Right == true && dash_State == false)
        {
            dash_State = true;
            dash_Counter = dash_Dur;

            player_rigidbody2D.gravityScale = 0;
            //player_rigidbody2D.AddForce(Vector2.right * dash_Strength, ForceMode2D.Impulse);
            player_rigidbody2D.velocity = Vector2.right * dash_Strength;
            doublePress_Script.doubePress_Right = false;
        }
        
        if (doublePress_Script.doubePress_Left == true && dash_State == false)
        {
            dash_State = true;
            dash_Counter = dash_Dur;

            player_rigidbody2D.gravityScale = 0;
            //player_rigidbody2D.AddForce(Vector2.right * dash_Strength, ForceMode2D.Impulse);
            player_rigidbody2D.velocity = Vector2.left * dash_Strength;
            doublePress_Script.doubePress_Left = false;
        }


        if (dash_State == true)
        {
            dash_Counter -= Time.deltaTime;

            if (dash_Counter <= 0)
            {
                dash_State = false;
                player_rigidbody2D.gravityScale = def_GravityScale;

            }
        }


    }
}
