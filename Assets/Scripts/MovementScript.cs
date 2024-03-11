using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D player_rigidbody2D;
    float walk_speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Walking Right");
            transform.position += Vector3.right * walk_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Walking Left");
            transform.position += Vector3.left * walk_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Jumping");
            //transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Crouching");
        }
    }

    private void FixedUpdate()
    {
        player_rigidbody2D.velocity = new Vector2(0, player_rigidbody2D.velocity.y);
    }
}
