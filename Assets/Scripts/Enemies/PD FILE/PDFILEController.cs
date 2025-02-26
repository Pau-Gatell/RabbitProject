using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PDFILEController : MonoBehaviour
{
    public float velocity;
    public Transform groundController;
    public float distance;
    public bool movementleft;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D informationGround = Physics2D.Raycast(groundController.position, Vector2.down, distance);
        rb.linearVelocity = new Vector2(velocity, rb.linearVelocity.y);

        if (informationGround == false)
        {
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
}
