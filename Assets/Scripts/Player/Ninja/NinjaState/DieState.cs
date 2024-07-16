using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : NinjaState
{
    public DieState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.animator.SetTrigger("Die");
        ninja.rb.velocity = Vector2.zero; // Stop all movement
    }

    public override void Update()
    {
        // No updates needed as the character is dead
    }

    public override void Exit()
    {
        // Reset any changes made during Enter (if necessary)
        ninja.animator.ResetTrigger("Die");
    }
}
