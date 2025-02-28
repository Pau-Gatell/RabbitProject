using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public Transform projectilePrefab;
    public Transform projectilePivot;
    public Animator cAnimator;

    public float projectileSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            //Debug.Log("He disparado");
        }
    }

    // I want to create a projectile
    private void Shoot()
    {
        Transform projectile = Instantiate(projectilePrefab);
        projectile.position = projectilePivot.position;
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.linearVelocity = Vector2.right * projectileSpeed;

        cAnimator.SetBool("Shoot", true);

    }
}
