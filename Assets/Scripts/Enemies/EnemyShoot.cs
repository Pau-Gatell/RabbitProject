using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float velocity;
    public int damage;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * velocity * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(TryGetComponent(out PlayerHealthController PlayerHealthController))
        {
            PlayerHealthController.Damage();
            Destroy(gameObject);
        }
    }
}
