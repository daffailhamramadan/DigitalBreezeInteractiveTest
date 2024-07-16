using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : NinjaState
{
    public RunState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.animator.SetTrigger("Run");
    }

    public override void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            // Flip the sprite based on the direction of input
            ninja.spriteRenderer.flipX = horizontalInput < 0;

            // Move the character using Rigidbody2D
            Vector2 movement = new Vector2(horizontalInput * ninja.moveSpeed, ninja.rb.velocity.y);
            ninja.rb.velocity = movement;
        }
        else
        {
            // Transition back to IdleState when there is no horizontal input
            ninja.ChangeState(new IdleState(ninja));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ninja.ChangeState(new JumpState(ninja));
        }
    }

    public override void Exit()
    {
        ninja.animator.ResetTrigger("Run");
    }
}


