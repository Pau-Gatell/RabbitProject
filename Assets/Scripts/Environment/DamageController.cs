using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public float damageForce = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos si el objeto tiene PlayerHealthController antes de llamar Damage()
        PlayerHealthController hCtr = collision.gameObject.GetComponent<PlayerHealthController>();
        if (hCtr != null)
        {
            hCtr.Damage();
        }
        else
        {
            Debug.LogWarning("PlayerHealthController no encontrado en " + collision.gameObject.name);
        }

        // Verificamos si el objeto tiene Rigidbody2D antes de aplicar la fuerza
        Rigidbody2D cRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        if (cRigidbody != null)
        {
            cRigidbody.AddForce(Vector2.up * damageForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("Rigidbody2D no encontrado en " + collision.gameObject.name);
        }
    }
}