using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningScript : MonoBehaviour
{
    DoublePress doublePress_Script;
    GroundedScript grounded_Script;
    MovementScript movement_Script;

    bool run_State;

    float def_walkSpeed;
    float def_runSpeed = 10;

    private void Start()
    {
        movement_Script = GetComponent<MovementScript>();
        doublePress_Script = GetComponent<DoublePress>();
        grounded_Script = GetComponentInChildren<GroundedScript>();

        def_walkSpeed = movement_Script.walk_speed;
    }

    private void Update()
    {

        if (doublePress_Script.doubePress_Right == true && run_State == false && grounded_Script.isGrounded == true)
        {
            run_State = true;
            movement_Script.walk_speed = def_runSpeed;
        }

        if (doublePress_Script.doubePress_Left == true && run_State == false && grounded_Script.isGrounded == true)
        {
            run_State = true;
            movement_Script.walk_speed = def_runSpeed;
        }

        else if (doublePress_Script.doubePress_Right == false && doublePress_Script.doubePress_Left == false && run_State == true && grounded_Script.isGrounded == true)
        {
            run_State = false;
            movement_Script.walk_speed = def_walkSpeed;
        }

        /*Essentially checks if the double press for each <- or -> is valid. If yes, the running action is executed. The action is done by accessing
        the movement_speed variable in the MovementScript and assigning it a higher value. When the double press button is lifted up (detected in
        the DoublePressScript), the movement_speed is assigned its default value before it was changed.*/

    }
}
