using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;

    private NinjaState currentState;

    private bool isHurt;
    private float hurtDuration = 0.5f;
    private float hurtStartTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeState(new IdleState(this));
    }

    void Update()
    {
        currentState.Update();

        if (isHurt && Time.time >= hurtStartTime + hurtDuration)
        {
            isHurt = false;
            spriteRenderer.color = Color.white; // Reset the color back to white
        }
    }

    public void ChangeState(NinjaState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }

    public void GetHurt()
    {
        isHurt = true;
        hurtStartTime = Time.time;
        spriteRenderer.color = Color.red;
    }

    public bool IsGrounded()
    {
        // Implement ground check logic
        return true;
    }
}
