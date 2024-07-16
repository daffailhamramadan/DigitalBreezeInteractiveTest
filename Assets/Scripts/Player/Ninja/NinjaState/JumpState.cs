using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : NinjaState
{
    private float jumpTime;
    private float jumpDuration = 0.2f; // Duration before checking for grounding

    public JumpState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.animator.SetTrigger("Jump");
        ninja.rb.velocity = new Vector2(ninja.rb.velocity.x, ninja.jumpForce);
        jumpTime = Time.time; // Record the time when the jump starts
    }

    public override void Update()
    {
        // Allow horizontal movement while jumping
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            // Flip the sprite based on the direction of input
            ninja.spriteRenderer.flipX = horizontalInput < 0;

            // Apply horizontal movement while in the air
            Vector2 movement = new Vector2(horizontalInput * ninja.moveSpeed, ninja.rb.velocity.y);
            ninja.rb.velocity = movement;
        }

        // Wait for jumpDuration before checking if grounded
        if (Time.time >= jumpTime + jumpDuration && ninja.IsGrounded())
        {
            ninja.ChangeState(new IdleState(ninja));
        }
    }

    public override void Exit()
    {
        ninja.animator.ResetTrigger("Jump");
    }
}
