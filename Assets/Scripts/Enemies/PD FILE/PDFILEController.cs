using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PDFILEController : MonoBehaviour
{
    public barPD healthbar;
    public Animator cAnimator;

    public float maxHealth = 100;

    private float health;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        health = maxHealth;
        healthbar.UpdateHealthbar(maxHealth, health);
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        healthbar.UpdateHealthbar(maxHealth, health);
        if (health > 0)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(damageDuration);
            spriteRenderer.color = Color.white;
        }
        else
        {
            cAnimator.SetBool("Death", true);
            Destroy(gameObject);
        }

    }

    void Update()
    {

    }
}
