using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // Desplazamiento de la cámara

    void Start()
    {
        // Ejemplo de desplazamiento: 2 unidades a la derecha y 1 arriba
        offset = new Vector3(2f, 1f, 0f);
    }

    void Update()
    {
        transform.position = new Vector3(
            player.transform.position.x + offset.x,
            player.transform.position.y + offset.y,
            transform.position.z
        );
    }
}
