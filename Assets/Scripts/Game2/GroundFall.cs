using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFall : MonoBehaviour
{
    [SerializeField] float minYValue = 0.65f;
    [SerializeField] float maxYValue = 2.5f;
    [SerializeField] float moveTime = 1f;
    [SerializeField] float waitTime = 0.5f;

    private bool exitCube;

    private CubeMovement cube;



    private void OnTriggerEnter(Collider other)
    {
        cube = other.GetComponent<CubeMovement>();
        if (cube != null)
        {
            exitCube = false;
            Fall();
        }
        
        //cube.Die();
    }
    
    private void Fall()
    {
        Sequence movementSequence = DOTween.Sequence();

        movementSequence
            .AppendInterval(waitTime)
            .AppendCallback(CheckCube)            
            .Append(transform.DOMoveY(minYValue, moveTime).SetEase(Ease.InExpo))
            .AppendInterval(waitTime * 4)
            .Append(transform.DOMoveY(maxYValue, moveTime));

    }
    private void OnTriggerExit(Collider other)
    {
        CubeMovement cubeLeft = other.GetComponent<CubeMovement>();

        if (cubeLeft != null)
        {
            exitCube = true;
        }
    }

    private void CheckCube()
    {
        if (!exitCube)
        {
            cube.Fall();
        }
    }
}
