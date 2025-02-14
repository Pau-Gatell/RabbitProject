using UnityEngine;
using DG.Tweening;

public class TweenOvni : MonoBehaviour
{
    public float speed = 5f;
    public float duartion = 2f;
    public Transform WaypointOvni; 
    void Start()
    {
        transform.DOMove(WaypointOvni.position, 2f)
        .SetEase(Ease.InQuad)
        .SetLoops(-1, LoopType.Yoyo);
        
    }
}
