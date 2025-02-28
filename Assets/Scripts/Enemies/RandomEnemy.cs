using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 5; 
    public float timeShoots = 3;


    private float health;
    private SpriteRenderer spriteRenderer;
    public float velocity;
    public Transform groundController;
    public Animator cAnimator;

    public float distance;
    public bool movementleft;
    public float detectionRadius;
    public GameObject player;
    public float fireRate = 1.5f;

    private bool playerDetected;
    private bool grounded;
    private Rigidbody2D rb;
    private float nextFireTime;

    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Testing"); // Asegura que tu jugador tenga la etiqueta "Player"
        }

        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        DetectPlayer();

        if (playerDetected)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void DetectPlayer()
    {
        if (player == null) return;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        playerDetected = distanceToPlayer <= detectionRadius;
    }

    private void ChasePlayer()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.linearVelocity = new Vector2(velocity, rb.linearVelocity.y);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.linearVelocity = new Vector2(-velocity, rb.linearVelocity.y);
        }
    }



    private void Patrol()
    {
        RaycastHit2D informationBorder = Physics2D.Raycast(groundController.position, Vector2.down, distance, LayerMask.GetMask("Environment"));
        RaycastHit2D informationGrounded = Physics2D.Raycast(transform.position, Vector2.down, distance, LayerMask.GetMask("Environment"));

        rb.linearVelocity = new Vector2(velocity, rb.linearVelocity.y);

        if (!informationBorder && informationGrounded)
        {
            Back();
        }
    }

    private void Back()
    {
        movementleft = !movementleft;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocity *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    private void OnMouseDown()
    {
        StartCoroutine(getDamage());
    }

    IEnumerator getDamage()
    {
        float damageDuration = 0.1f;
        float damage = 2f;
        health -= damage;
        if (health > 0)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(damageDuration);
            spriteRenderer.color = Color.white;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}