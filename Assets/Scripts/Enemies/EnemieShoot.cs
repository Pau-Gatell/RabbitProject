using UnityEngine;

public class EnemieShoot : MonoBehaviour
{

    public Transform controllerShoot;

    public float distanceline;
    public bool playerRange;

    public LayerMask capePlayer;
    

    void Start()
    {
        
    }

    void Update()
    {
        playerRange = Physics2D.Raycast(controllerShoot.position, transform.right, distanceline, capePlayer);

        if (playerRange) { }
    }



}

