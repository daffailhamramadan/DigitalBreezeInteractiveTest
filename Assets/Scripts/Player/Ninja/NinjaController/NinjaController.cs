using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    private bool isHurt;
    private float hurtDuration = 0.5f;
    private float hurtStartTime;

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

            if (isHurt && Time.time >= hurtStartTime + hurtDuration)
            {
                isHurt = false;
                spriteRenderer.color = Color.white; // Reset the color back to white
            }
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

    public void GetHurt()
    {
        isHurt = true;
        hurtStartTime = Time.time;
        spriteRenderer.color = Color.red;
    }

    public bool IsGrounded()
    {
        // Check if the character is grounded
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}

