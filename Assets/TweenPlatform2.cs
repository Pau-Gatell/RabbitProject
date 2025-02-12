using DG.Tweening;
using UnityEngine;

public class TweenPlatform2 : MonoBehaviour
{
    public float speed = 2f;
    public float duration = 2f;
    public Transform Waypoint2;
   
    void Start()
    {
        transform.DOMove(Waypoint2.position, 2f)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Yoyo);
    }

}
