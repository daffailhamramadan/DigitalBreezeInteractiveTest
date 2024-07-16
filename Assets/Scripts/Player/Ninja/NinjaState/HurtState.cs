using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : NinjaState
{
    private float hurtDuration = 0.5f; // Duration for which the sprite stays red
    private float hurtStartTime;

    public HurtState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.spriteRenderer.color = Color.red;
        hurtStartTime = Time.time;
    }

    public override void Update()
    {
        if (Time.time >= hurtStartTime + hurtDuration)
        {
            ninja.spriteRenderer.color = Color.white; // Reset the color back to white

            if (ninja.IsGrounded())
            {
                ninja.ChangeState(new IdleState(ninja));
            }
        }
    }

    public override void Exit()
    {
        
    }
}

