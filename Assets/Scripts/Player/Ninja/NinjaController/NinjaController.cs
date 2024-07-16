using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    private NinjaState currentState;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeState(new IdleState(this));
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }

    public void ChangeState(NinjaState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    public bool IsGrounded()
    {
        // Implement ground check logic
        return true;
    }
}
