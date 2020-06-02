using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] float minYValue = 0.65f;
    [SerializeField] float maxYValue = 2.5f;
    [SerializeField] float moveTime = 1f;
    [SerializeField] float duration = 2f;
    [SerializeField] float strength=  0.1f;
    [SerializeField] float randomnes = 10f;
    [SerializeField] int vibrato = 30;

    float waitTime;
    


    // Start is called before the first frame update
    void Start()
    {
        ButtonOfBlock button = FindObjectOfType<ButtonOfBlock>();
        button.onPressedChanged += MoveBlock;
        waitTime = button.WaitTime;
        
        
    }

    public void MoveBlock()
    {
       
        Sequence movementSequence = DOTween.Sequence();

        movementSequence.Append(transform.DOMoveY(maxYValue, moveTime))
            .AppendInterval(waitTime)
            .Append(transform.DOShakePosition(duration, strength, vibrato, randomnes))
            .Append(transform.DOMoveY(minYValue, moveTime));

    }

    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        cube.Die();
    }
}
