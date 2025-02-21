using UnityEngine;
using DG.Tweening;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float velocity = 2f;
    public float duration = 2f;
    public Transform Waypoint0;

    void Start()
    {
        Vector3 posicionInicial = transform.position;

        transform.DOMove(Waypoint0.position, 2f)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Yoyo);
    }

}
