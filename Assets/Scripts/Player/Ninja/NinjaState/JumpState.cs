using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : NinjaState
{
    public JumpState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.animator.SetTrigger("Jump");
    }

    public override void Update()
    {
        if (ninja.IsGrounded())
        {
            ninja.ChangeState(new IdleState(ninja));
        }
    }

    public override void Exit()
    {
        ninja.animator.ResetTrigger("Jump");
    }
}
