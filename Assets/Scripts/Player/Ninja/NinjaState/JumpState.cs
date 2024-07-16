using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : NinjaState
{
    private float jumpTime;
    private float jumpDuration = 0.2f;

    public JumpState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.animator.SetTrigger("Jump");
        ninja.rb.velocity = new Vector2(ninja.rb.velocity.x, ninja.jumpForce);
        jumpTime = Time.time;
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

        if (Time.time >= jumpTime + jumpDuration && ninja.IsGrounded())
        {
            ninja.ChangeState(new IdleState(ninja));
        }

        if (Input.GetKeyDown(KeyCode.H)) // Press 'H' key to simulate getting hurt
        {
            ninja.GetHurt();
        }
    }

    public override void Exit()
    {
        ninja.animator.ResetTrigger("Jump");
    }
}
