using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemiy : MonoBehaviour
{
    public float velocity;
    public Transform groundController;
    public float distance;
    public bool movementleft;

    private bool grounded;

    private Rigidbody2D rb;

        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D informationBorder = Physics2D.Raycast(groundController.position, Vector2.down, distance, LayerMask.GetMask("Environment"));
        RaycastHit2D informationGrounded = Physics2D.Raycast(transform.position, Vector2.down, distance, LayerMask.GetMask("Environment"));

        rb.linearVelocity = new Vector2(velocity, rb.linearVelocity.y);
        Debug.Log("Patrullando");

        if (informationBorder == false && informationGrounded == true)
        {
            //Debug.Log("Patrullando");
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
        Gizmos.DrawLine(groundController.transform.position, groundController.transform.position + Vector3.down * distance);
    }

    //void OnCollisionStay2D(Collision2D collision)
    //{
    //    grounded = true;
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    grounded = false;
    //}
}

