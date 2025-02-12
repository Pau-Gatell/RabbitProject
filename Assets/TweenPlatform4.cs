using DG.Tweening;
using UnityEngine;

public class TweenPlatform4 : MonoBehaviour
{
    public float speed = 2f;
    public float duration = 2f;
    public Transform Waypoint4;
   
    void Start()
    {
        transform.DOMove(Waypoint4.position, 2f)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Yoyo);
    }


}
