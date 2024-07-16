using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : NinjaState
{
    public IdleState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.animator.SetTrigger("Idle");
    }

    public override void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            ninja.ChangeState(new RunState(ninja));
        }
        else if (Input.GetKeyDown(KeyCode.Space) && ninja.IsGrounded())
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
        ninja.animator.ResetTrigger("Idle");
    }
}
