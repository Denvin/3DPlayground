using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pendulum : MonoBehaviour
{
    [SerializeField] Vector3 rotatePendulum;
    [SerializeField] float duration;



    // Start is called before the first frame update
    void Start()
    {
        Sequence movementSequence = DOTween.Sequence();
        movementSequence.Append(transform.DORotate(rotatePendulum, duration).SetEase(Ease.InOutExpo))
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        cube.Die();
    }
}
