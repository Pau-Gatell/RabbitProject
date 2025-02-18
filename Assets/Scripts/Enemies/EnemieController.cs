using DG.Tweening;
using UnityEngine;
public class EnemieController : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;
    void Start()
    {
        EnemiesMoves();
    }

    void EnemiesMoves()
    {
        transform.DOMove(waypoint2.position, 3f).SetDelay(1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOMove(waypoint1.position, 3f).SetDelay(1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                EnemiesMoves();
            });
        });
    }


    void Update()
    {
        
    }
}
