using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : NinjaState
{
    public AttackState(NinjaController ninja) : base(ninja) { }

    public override void Enter()
    {
        ninja.animator.SetTrigger("Attack");
        // Optionally stop horizontal movement during attack
        ninja.rb.velocity = new Vector2(0, ninja.rb.velocity.y);
    }

    public override void Update()
    {
        // Transition back to IdleState or RunState based on input after the attack animation completes
        if (ninja.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                ninja.ChangeState(new RunState(ninja));
            }
            else
            {
                ninja.ChangeState(new IdleState(ninja));
            }
        }
    }

    public override void Exit()
    {
        ninja.animator.ResetTrigger("Attack");
    }
}
