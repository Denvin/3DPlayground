using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ButtonOfBlock button;

    [Header("Movement")]
    [SerializeField] bool xMove;
    [SerializeField] bool zMove;
    
    [SerializeField] float minXValue = 1f;
    [SerializeField] float maxXValue = -1f;
    [SerializeField] float minZValue = 3f;
    [SerializeField] float maxZValue = -3f;
    [SerializeField] float moveTime = 3f;

    private bool stopMovement;
    private Sequence movementSequence;


    // Start is called before the first frame update
    void Start()
    {
        stopMovement = true;
        //movementSequence = DOTween.Sequence();
        

        CheckAxisMovement();
        button.onPressedRelease += StopMovement;
    }
    private void Update()
    {
        CheckStopMovement();
    }

    private void CheckAxisMovement()
    {
        if (xMove && !zMove)
        {
            button.onPressed += MoveBridgeX;
        }
        else if (zMove && !xMove)
        {
            button.onPressed += MoveBridgeZ;
        }
        else
        {
            Debug.Log("Укажите ось движения!");
        }
    }
    private void MoveBridgeX()
    {
        stopMovement = false;
        if (movementSequence == null)
        {
            movementSequence = DOTween.Sequence();
            movementSequence.Append(transform.DOMoveX(maxXValue, moveTime))
                .Append(transform.DOMoveX(minXValue, moveTime))
                .SetLoops(-1, LoopType.Yoyo);
        }
        else
        {
            movementSequence.Play();
        }
        
            
    }
    private void MoveBridgeZ()
    {
        stopMovement = false;
        if (movementSequence == null)
        {
            movementSequence = DOTween.Sequence();
            movementSequence.Append(transform.DOMoveZ(maxZValue, moveTime))
                .Append(transform.DOMoveZ(minZValue, moveTime))
                .SetLoops(-1, LoopType.Yoyo);
        }
        else
        {
            movementSequence.Play();
        }
                  
    }

    private void CheckStopMovement()
    {
        if (stopMovement)
        {
            movementSequence.Pause();
        }
    }
    private void StopMovement()
    {
        stopMovement = true;
    }
}
