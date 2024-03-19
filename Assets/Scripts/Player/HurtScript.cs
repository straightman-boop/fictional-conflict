using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtScript : MonoBehaviour
{
    /*HurtScript detects whether the player has been hit. If yes, the player is stuck in a hurt state where they cannot move.
    Once hit, there will be a slight delay where the player can recover.*/

    [HideInInspector] public bool isHurt = false;
    bool calledFunction = false;
    float isHurt_Cooldown = 0.7f;
    float isHurt_Counter;

    MovementScript movement_Script;
    DoublePress doublePress_Script;
    Rigidbody2D rigidbody2d;

    float def_gravityScale;

    // Start is called before the first frame update
    void Start()
    {
        movement_Script = GetComponentInParent<MovementScript>();   /*References script to stop functioning during hurt state*/
        doublePress_Script = GetComponentInParent<DoublePress>();
        rigidbody2d = GetComponentInParent<Rigidbody2D>();

        def_gravityScale = rigidbody2d.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHurt == true && calledFunction == false)             /*One way entry to call function*/
        {
            calledFunction = true;
            HurtState();
        }

        if (isHurt == true)                                        /*Continuos flow; Hurt counter till recovery*/
        {
            isHurt_Counter -= Time.deltaTime;

            if (isHurt_Counter <= 0)
            {
                RecoverState();
            }
        }
    }

    void HurtState()                                               /*Start of hurt state*/
    {
        Debug.Log("HURT!!! OW OW OW!!!");
        movement_Script.enabled = false;
        doublePress_Script.enabled = false;
        rigidbody2d.gravityScale = 0;
        rigidbody2d.velocity = Vector2.zero;

        isHurt_Counter = isHurt_Cooldown;
    }

    void RecoverState()                                            /*End of hurt state*/
    {
        Debug.Log("RECOVERED!!!");
        movement_Script.enabled = true;
        doublePress_Script.enabled = true;
        rigidbody2d.gravityScale = def_gravityScale;

        isHurt = false;
        calledFunction = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)            /*Contesting between use of ontriggerSTAY vs ontriggerENTER*/
    {
        isHurt = true;
    }

    /*Stunlocks player; Has recovery state and cooldown*/
}
