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
            ninja.spriteRenderer.flipX = horizontalInput < 0;
            Vector2 movement = new Vector2(horizontalInput * ninja.moveSpeed, ninja.rb.velocity.y);
            ninja.rb.velocity = movement;
        }
        else
        {
            ninja.ChangeState(new IdleState(ninja));
        }

        if (Input.GetKeyDown(KeyCode.Space) && ninja.IsGrounded())
        {
            ninja.ChangeState(new JumpState(ninja));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ninja.ChangeState(new AttackState(ninja));
        }
        else if (Input.GetKeyDown(KeyCode.H)) // Press 'H' key to simulate getting hurt
        {
            ninja.GetHurt();
        }
    }

    public override void Exit()
    {
        ninja.animator.ResetTrigger("Run");
    }
}

