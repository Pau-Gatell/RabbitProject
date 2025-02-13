using UnityEngine;
using DG.Tweening;
public class TweenPlatform1 : MonoBehaviour
{
    public float speed = 0.2f;
    public float duration = 6f;
    public Transform Waypoint1;
    
    void Start()
    {
        transform.DOMove(Waypoint1.position, 2f)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Yoyo);
    }

}
