using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour
{
    [SerializeField] float maxYValue = 0.2f;
    [SerializeField] float moveTime = 1;
    [SerializeField] float waitTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        /*Sequence movementSequence = DOTween.Sequence();
        
        movementSequence.AppendInterval(waitTime);
        movementSequence.Append(transform.DOMoveY(maxYValue, moveTime));
        movementSequence.AppendCallback(PrintUp);
        movementSequence.AppendInterval(waitTime);
        movementSequence.Append(transform.DOMoveY(0, moveTime));
        movementSequence.SetLoops(-1);*/

        Sequence movementSequence2 = DOTween.Sequence();
        movementSequence2.AppendInterval(waitTime/2)
            .Append(transform.DOMoveY(maxYValue, moveTime).SetEase(Ease.InExpo))
            .AppendInterval(waitTime/2)
            .SetLoops(-1, LoopType.Yoyo);
    }

    void PrintUp()
    {
        Debug.Log("I am up!");
    }

    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        cube.Die();
    }
}
