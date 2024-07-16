using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : NinjaState
{
    public HurtState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.animator.SetTrigger("Hurt");
    }

    public override void Update()
    {
        // Logic to transition after hurt
        ninja.ChangeState(new IdleState(ninja));
    }

    public override void Exit()
    {
        ninja.animator.ResetTrigger("Hurt");
    }
}

