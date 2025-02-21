using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthController hCtr = collision.gameObject.GetComponent<PlayerHealthController>();
        hCtr.Regenerate();

        Debug.Log(collision.name);

        Destroy(this.gameObject); 
    }
}
