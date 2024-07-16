using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : NinjaState
{
    public AttackState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.animator.SetTrigger("Attack");
    }

    public override void Update()
    {
        // Logic to transition after attack
        ninja.ChangeState(new IdleState(ninja));
    }

    public override void Exit()
    {
        ninja.animator.ResetTrigger("Attack");
    }
}


