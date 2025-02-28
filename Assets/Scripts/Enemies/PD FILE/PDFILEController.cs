using UnityEngine;

public class PDFileController : MonoBehaviour
{
    public float speed = 3;
    public float minDistance = 5f;
    public Transform player;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    private int hitCount = 0; // Contador de impactos
    private int maxHits = 3; // Número máximo de impactos antes de desaparecer

    void Start()
    {
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

    public void TakeDamage()
    {
        hitCount++;
        if (hitCount >= maxHits)
        {
            Destroy(gameObject); // Destruye el enemigo cuando recibe 3 impactos
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Bullet")) // Detecta balas sin depender de etiquetas
        {
            TakeDamage();
            Destroy(collision.gameObject); // Destruye la bala al impactar
        }
    }
}
