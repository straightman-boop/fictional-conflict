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
    public bool doubePress_Down;

    private void Start()
    {
        doubePress_Right = false;
        doubePress_Left = false;
        doubePress_Down = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            float timeSinceLastPress = Time.time - lastPressedTimeL;

            if (timeSinceLastPress <= DOUBLE_PRESS_TIME)
            {
                Debug.Log("Double Press DOWN!");
                //return true;
            }
            else
            {
                Debug.Log("DOWN!");
            }

            lastPressedTimeL = Time.time;
            //return false;

        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            float timeSinceLastPress = Time.time - lastPressedTimeL;

            if (timeSinceLastPress <= DOUBLE_PRESS_TIME)
            {
                Debug.Log("Double Press LEFT!");
                doubePress_Left = true;
                //return true;
            }
            else
            {
                Debug.Log("LEFT!");
            }

            lastPressedTimeL = Time.time;
            //return false;

        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            float timeSinceLastPress = Time.time - lastPressedTimeR;

            if (timeSinceLastPress <= DOUBLE_PRESS_TIME)
            {
                Debug.Log("Double Press RIGHT!");
                doubePress_Right = true;
                //return true;
            }
            else
            {
                Debug.Log("RIGHT!");
            }

            lastPressedTimeR = Time.time;
            //return false;
        }

        //else
        //    return false;
    }
}
