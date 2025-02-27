using UnityEditor.Tilemaps;
using UnityEngine;

public class TestingEnemy : MonoBehaviour
{
    public float speed = 3;
    public float minDistance = 5f;
    public Transform player;

    private bool isFacingRight = true;
    private Rigidbody2D rb;


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
        else 
        {
            Attack();
        }


        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);
    }


    private void Attack()
    {
        Debug.Log("Atacar");
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
}
