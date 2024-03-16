using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePress : MonoBehaviour
{
    private float lastPressedTimeR;
    private float lastPressedTimeL;
    private const float DOUBLE_PRESS_TIME = 0.2f;

    [HideInInspector]
    public bool doubePress_Right;
    [HideInInspector]
    public bool doubePress_Left;
    [HideInInspector]
    public bool doubePress_Right_aerial;
    [HideInInspector]
    public bool doubePress_Left_aerial;
    [HideInInspector]
    public bool doubePress_Down;

    GroundedScript grounded_Script;

    private void Start()
    {
        doubePress_Right = false;
        doubePress_Left = false;
        doubePress_Down = false;

        grounded_Script = GetComponentInChildren<GroundedScript>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            float timeSinceLastPress = Time.time - lastPressedTimeL;

            if (timeSinceLastPress <= DOUBLE_PRESS_TIME) //Debug.Log("Double Press DOWN!");
            {

            }
            else //Debug.Log("Single Press DOWN!");
            {

            }

            lastPressedTimeL = Time.time;

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            float timeSinceLastPress = Time.time - lastPressedTimeL;

            if (timeSinceLastPress <= DOUBLE_PRESS_TIME)
            {
                if (grounded_Script.isGrounded == false)
                {
                    doubePress_Left_aerial = true;
                }


                else
                {
                    doubePress_Left = true;
                }
            }
            else //Debug.Log("Single Press LEFT!");
            {

            }

            lastPressedTimeL = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            float timeSinceLastPress = Time.time - lastPressedTimeR;

            if (timeSinceLastPress <= DOUBLE_PRESS_TIME) //Debug.Log("Double Press RIGHT!");  
            {
                if (grounded_Script.isGrounded == false)
                {
                    doubePress_Right_aerial = true;
                }


                else
                {
                    doubePress_Right = true;
                }


            }
            else //Debug.Log("Single Press RIGHT!");
            {

            }

            lastPressedTimeR = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            doubePress_Right = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            doubePress_Left = false;
        }

    }

    /*Acts as a script designed to catch double presses for each direction button. It is connected to multiple scripts that may need its variables.
    Simple time counter algorithm to check the elapsed time between presses to count it as a valid "double press input". There are conditionals
    that determine whether a press is a single or double button press for flexibility.*/

}
