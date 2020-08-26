using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class ButtonOfBlock : MonoBehaviour
{
    
    public Action onPressed = delegate { };
    public Action onPressedRelease = delegate { };
    [SerializeField] float minYValue = -0.12f;
    [SerializeField] float maxYValue = 0f;
    [SerializeField] float moveTime = 1;
    [SerializeField] float waitTime = 1;

    Sequence movementSequence;

    public float WaitTime
    {
        get
        {
            return waitTime;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        onPressed();
        
        Sequence movementSequence = DOTween.Sequence();
        movementSequence.Append(transform.DOMoveY(minYValue, moveTime));
            
    }
    private void OnTriggerExit(Collider other)
    {
        onPressedRelease();
        Sequence movementSequence = DOTween.Sequence();
        movementSequence.Append(transform.DOMoveY(maxYValue, moveTime));
    }
}
