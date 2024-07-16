using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : NinjaState
{
    public DieState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.animator.SetTrigger("Die");
    }

    public override void Update()
    {
        // No transition out of DieState
    }

    public override void Exit()
    {
        // Any cleanup for leaving the state
    }
}

