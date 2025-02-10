using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController INSTANCE;

    public float speed = 5f;
    public float jumpForce = 3f;
    public float ceilDistance = 1f;
    public float gravity = 2f;

    public Animator cAnimator;
    public SpriteRenderer cRenderer;
    public Rigidbody2D cRigidbody;
    public CapsuleCollider2D cCollider;

    private Vector2 move;
    private Vector2 normal;
    private bool grounded;
    private bool crouched;

    private bool jumpKey;
    private bool crouchKey;

    private Vector3 m_Velocity = Vector3.zero;

    void Start()
    {
        INSTANCE = this;
    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        jumpKey = Input.GetKeyDown(KeyCode.W);
        crouchKey = Input.GetKey(KeyCode.S);

        if (jumpKey && grounded)
        {
            cRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 

            cAnimator.SetBool("Jump", true);
            Debug.Log("Jump");

        }

        cAnimator.SetFloat("Speed", Mathf.Abs(cRigidbody.linearVelocity.x));

        PlayerOrientation();
    }

    void FixedUpdate()
    {
        PlayerGrounded();
        PlayerCrouched();

        Vector2 dir = new Vector2(normal.y, normal.x) * move.x;
        Vector2 targetVelocity = new Vector2(move.x * speed, cRigidbody.linearVelocity.y);
        cRigidbody.linearVelocity = Vector3.SmoothDamp(cRigidbody.linearVelocity, targetVelocity, ref m_Velocity, 0.05f);
    }

    void PlayerOrientation()
    {
        if (move.x < 0)
            cRenderer.flipX = true;
        else if (move.x > 0)
            cRenderer.flipX = false;
    }

    void PlayerGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.2f, Vector2.down, 0.35f, LayerMask.GetMask("Environment"));
        RaycastHit2D surfaceHit = Physics2D.Raycast(transform.position + Vector3.up * 1f, Vector2.down, 10f, LayerMask.GetMask("Environment"));

        normal = surfaceHit ? hit.normal : Vector3.down;

        if (hit && !grounded) 
        {
            grounded = true;
            cAnimator.SetBool("Jump", false);
        }
        else if (!hit)
        {
            grounded = false;
        }

        if (!hit && cRigidbody.linearVelocity.y < 0)
        {
            cAnimator.SetBool("Fall", true);
            cAnimator.SetBool("Jump", false);
        }
        else
        {
            cAnimator.SetBool("Fall", false);
        }
    }

    void PlayerCrouched()
    {
        bool hit = Physics2D.Raycast(transform.position + Vector3.up * 0.1f, Vector2.up, ceilDistance, LayerMask.GetMask("Environment"));
        bool isCrouched = hit || crouchKey;

        if (isCrouched)
        {
            cCollider.size = new Vector2(cCollider.size.x, 0.17f);
            cCollider.offset = new Vector2(0, 0.09f);
            crouched = true;
        }
        else
        {
            cCollider.size = new Vector2(cCollider.size.x, 0.26f);
            cCollider.offset = new Vector2(0, 0.13f);
            crouched = false;
        }

        cAnimator.SetBool("Crouch", isCrouched);
    }
}
