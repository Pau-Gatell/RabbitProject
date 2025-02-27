using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject shootPrefab;
    public float timeShoots = 10;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeShoots);
            Instantiate(shootPrefab, transform.position, Quaternion.identity);
        }
    }

}
