using UnityEngine;
using DG.Tweening;

public class TweenPlatform4 : MonoBehaviour
{
    public float speed = 5f;
    public float delay = 2f; 
    public Transform Waypoint4;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; 

        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(Waypoint4.position, speed).SetEase(Ease.Linear))
                .AppendInterval(delay) 
                .Append(transform.DOMove(initialPosition, speed).SetEase(Ease.Linear))
                .AppendInterval(delay) 
                .SetLoops(-1); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            other.transform.SetParent(transform);
        }
    }

   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
