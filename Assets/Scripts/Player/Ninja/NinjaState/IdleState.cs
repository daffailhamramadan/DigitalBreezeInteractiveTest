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
            // Transition to RunState when there is horizontal input
            ninja.ChangeState(new RunState(ninja));
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ninja.ChangeState(new JumpState(ninja));
        }
    }

    public override void Exit()
    {
        ninja.animator.ResetTrigger("Idle");
    }
}
