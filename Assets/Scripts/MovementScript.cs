using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D player_rigidbody2D;
    float walk_speed = 3;
    float jump_force = 4;

    float move_horizontal;
    float move_vertical;

    GroundedScript grounded_Script;

    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody2D = GetComponent<Rigidbody2D>();
        grounded_Script = GetComponentInChildren<GroundedScript>();
    }

    // Update is called once per frame
    void Update()
    {
        move_horizontal = Input.GetAxisRaw("Horizontal");
        move_vertical = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        if (move_horizontal > 0.1f)
        {
            transform.position += Vector3.right * walk_speed * Time.deltaTime;
            //Debug.Log("Walking Right");
        }

        else if (move_horizontal < -0.1f)
        {
            transform.position += Vector3.left * walk_speed * Time.deltaTime;
            //Debug.Log("Walking Left");
        }

        if (move_vertical > 0.1f && grounded_Script.isGrounded == true)
        {
            player_rigidbody2D.velocity = Vector2.up * jump_force;

            //player_rigidbody2D.AddForce(new Vector2(0f, move_vertical * jump_force), ForceMode2D.Impulse);
            //using addforce created bugs where the jump is inconsistent. the height grew after each bounce.
        }

        Debug.Log(move_vertical);
    }
}
