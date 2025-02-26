using System.Collections;
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
