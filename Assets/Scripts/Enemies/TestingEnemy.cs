using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TestingEnemy : MonoBehaviour
{
    public float speed = 3;
    public float minDistance = 5f;
    public Transform player;
    private bool isFacingRight = true;
    private Rigidbody2D rb;

    public float maxHealth = 5;

    private float health;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);
    }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
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
