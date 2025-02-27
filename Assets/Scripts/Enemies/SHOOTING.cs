using System.Collections;
using UnityEngine;

public class SHOOTING : MonoBehaviour
{
    public float speed = 12;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = FindAnyObjectByType<PlayerController>().transform;
        rb = GetComponent<Rigidbody2D>();

        LaunchShooting();
    }

    void Update()
    {
        
    }

    private void LaunchShooting()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        rb.linearVelocity = directionToPlayer * speed;
        StartCoroutine(DestroyShooting());
    }

    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }

    IEnumerator DestroyShooting()
    { 
        float destroyTime = 10f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
