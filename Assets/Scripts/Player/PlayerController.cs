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
    public int maxJumps = 1;

    public Animator cAnimator;
    public SpriteRenderer cRenderer;
    public Rigidbody2D cRigidbody; 
    public CapsuleCollider2D cCollider;
    public PlayerHealthController cHealth;

    private Vector2 move;
    private Vector2 normal;
    private bool grounded;

    private bool jumpKey;
    private int jumpCount;
    private bool crouchKey;

    private Vector3 m_Velocity = Vector3.zero;

    void Start()
    {
        INSTANCE = this;
        jumpCount = 0;

    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        jumpKey = Input.GetKeyDown(KeyCode.W);

        if (jumpKey && jumpCount < maxJumps)
        {
            cRigidbody.linearVelocity = new Vector2(cRigidbody.linearVelocity.x, 0);
            cRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            jumpCount++;
            cAnimator.SetBool("Jump", true);

            Debug.Log($"Jump {jumpCount}");
        }

        cAnimator.SetFloat("Speed", Mathf.Abs(cRigidbody.linearVelocity.x));

        PlayerOrientation();
    }

    void FixedUpdate()
    {
        PlayerGrounded();

        Vector2 dir = new Vector2(normal.y, normal.x) * move.x;
        Vector2 targetVelocity = new Vector2(move.x * speed, cRigidbody.linearVelocity.y);
        cRigidbody.linearVelocity = Vector3.SmoothDamp(cRigidbody.linearVelocity, targetVelocity, ref m_Velocity, 0.05f);
    }

    void PlayerOrientation()
    {
        if (move.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
        }
        else if (move.x > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    void PlayerGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2.5f, LayerMask.GetMask("Environment"));

        if (hit.collider != null) // Verifica que haya contacto con el suelo
        {
            grounded = true;
            jumpCount = 0;
            cAnimator.SetBool("Jump", false);
            cAnimator.SetBool("Fall", false);
        }
        else
        {
            grounded = false;
            if (cRigidbody.linearVelocity.y < 0)
            {
                cAnimator.SetBool("Fall", true);
            }
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

}
