using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D player_rigidbody2D;
    float walk_speed = 3;
    float jump_force = 12;
    float jump_force_horizontal = 8;

    float jump_TimeCounter;
    float jump_Time = 0.3f;
    bool isJumping;

    float move_horizontal;

    float def_x = 0.2f;
    float def_y = 1.5f;

    GroundedScript grounded_Script;
    DoublePress double_press_Script;

    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody2D = GetComponent<Rigidbody2D>();
        grounded_Script = GetComponentInChildren<GroundedScript>();
        double_press_Script = GetComponent<DoublePress>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player_rigidbody2D.gravityScale);

        move_horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.W) && grounded_Script.isGrounded == true) //Checks input for Jump & if grounded.
        {
            if (Input.GetKey(KeyCode.D)) //Checks input if left. Automatic curved jump.
            {
                isJumping = true;
                jump_TimeCounter = jump_Time;
                player_rigidbody2D.velocity = new Vector2(def_x, def_y) * jump_force_horizontal;


            }
            
            else if (Input.GetKey(KeyCode.A)) //Checks input if right. Automatic curved jump.
            {
                isJumping = true;
                jump_TimeCounter = jump_Time;
                player_rigidbody2D.velocity = new Vector2(-def_x, def_y) * jump_force_horizontal;

            }

            else //Checks input if stationary. Automatic vertical jump.
            {
                isJumping = true;
                jump_TimeCounter = jump_Time;
                player_rigidbody2D.velocity = Vector2.up * jump_force;
            }

        }

        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jump_TimeCounter > 0)
            {
                //player_rigidbody2D.velocity = Vector2.up * jump_force;
                jump_TimeCounter -= Time.deltaTime;
            }

            else
            {
                isJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }

    }

    private void FixedUpdate()
    {
        if (move_horizontal > 0.1f && grounded_Script.isGrounded == true)
        {
            transform.position += Vector3.right * walk_speed * Time.deltaTime;
            //Debug.Log("Walking Right");
        }

        else if (move_horizontal < -0.1f && grounded_Script.isGrounded == true)
        {
            transform.position += Vector3.left * walk_speed * Time.deltaTime;
            //Debug.Log("Walking Left");
        }

    }
}
