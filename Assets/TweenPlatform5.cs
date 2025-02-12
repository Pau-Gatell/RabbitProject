using DG.Tweening;
using UnityEngine;

public class TweenPlatform5 : MonoBehaviour
{
    public float speed = 2f;
    public float duration = 2f;
    public Transform Waypoint5;
    
    void Start()
    {
        transform.DOMove(Waypoint5.position, 2f)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Yoyo);
    }


}