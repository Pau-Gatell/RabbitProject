using UnityEngine;
using DG.Tweening;

public class TweenPlatform5 : MonoBehaviour
{
    public float speed = 5f;
    public float delay = 2f; // Tiempo de espera en cada extremo
    public Transform Waypoint5;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // Guarda la posición inicial

        // Creamos una secuencia de movimientos
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(Waypoint5.position, speed).SetEase(Ease.Linear))
                .AppendInterval(delay) // Espera cuando llega arriba
                .Append(transform.DOMove(initialPosition, speed).SetEase(Ease.Linear))
                .AppendInterval(delay) // Espera cuando llega abajo
                .SetLoops(-1); // Repite infinitamente
    }
}
