using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class EnemieController : MonoBehaviour
{
    public Transform shootController;
    public float distanceLine;
    public bool playerRange;
    public LayerMask player;

    public GameObject ShootEnemy;
    public float timeShoot;
    public float lastShoot;

    void Start()
    {

    }

    void Update()
    {
        playerRange = Physics2D.Raycast(shootController.position, transform.right, distanceLine, player);

        if (playerRange) {
            if (Time.time > timeShoot + lastShoot)
            { 
                lastShoot = Time.time;
                Invoke(nameof(EnemyShoot), timeShoot);
            }
        }
    }

    private void Shooting()
    {
        Instantiate(ShootEnemy, shootController.position, shootController.rotation);
    
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(shootController.position, shootController.position + transform.right * distanceLine);
    }
}