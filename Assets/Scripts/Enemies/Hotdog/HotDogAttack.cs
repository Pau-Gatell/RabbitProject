using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HotDogAttack : MonoBehaviour
{
    public Rigidbody2D cRigidbody;
    public float damageForce = 5f;
    private PlayerController player;

    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthController hCtr = collision.gameObject.GetComponent<PlayerHealthController>();

        if (hCtr)
        {
            hCtr.Damage();

            Rigidbody2D cRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            cRigidbody.AddForce(Vector2.up * damageForce, ForceMode2D.Impulse); 

            Debug.Log(collision.name);
        }
    }
}
