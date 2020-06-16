using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ButtonOfBlock button;

    [Header("Movement")]
    [SerializeField] float minYValue = 0.65f;
    [SerializeField] float maxYValue = 2.5f;
    [SerializeField] float moveTimeUp = 1f;
    [SerializeField] float moveTimeDown = 1f;
    [SerializeField] float waitTime = 2f;

    [Header("Shake effect")]
    [SerializeField] float duration = 2f;
    [SerializeField] float strength=  0.1f;
    [SerializeField] float randomnes = 10f;
    [SerializeField] int vibrato = 30;





    // Start is called before the first frame update
    void Start()
    {


        button.onPressed += MoveUpBlock;
        button.onPressedRelease += MoveDownBlock;
               
    }

    public void MoveUpBlock()
    {
        Sequence movementSequence = DOTween.Sequence();
        movementSequence.Append(transform.DOMoveY(maxYValue, moveTimeUp));                  
    }
    public void MoveDownBlock()
    {
        Sequence movementSequence = DOTween.Sequence();
        movementSequence.AppendInterval(waitTime)
            .Append(transform.DOShakePosition(duration, strength, vibrato, randomnes))
            .Append(transform.DOMoveY(minYValue, moveTimeDown));
    }

    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        cube.Die();
    }
}
