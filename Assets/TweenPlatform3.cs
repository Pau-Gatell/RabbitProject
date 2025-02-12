using DG.Tweening;
using UnityEngine;

public class TweenPlatform3 : MonoBehaviour
{
    public float speed = 2f;
    public float duration = 2f;
    public Transform Waypoint3;
   
    void Start()
    {
        transform.DOMove(Waypoint3.position, 2f)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Yoyo);
    }

}