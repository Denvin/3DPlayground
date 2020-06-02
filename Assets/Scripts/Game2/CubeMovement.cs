using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public class CubeMovement : MonoBehaviour
{
    public GameObject destroyFX;

    [SerializeField] float moveTime = 0.5f;
    [SerializeField] float jumpPower = 1f;
    [SerializeField] float reloadLevelDelay = 1f;

    bool allowInput;

    public void Die()
    {
        Vector3 fxPosition = transform.position;
        
        if (destroyFX != null)
        {
            Instantiate(destroyFX, fxPosition, Quaternion.identity);
        }
        //TODO play sound
        Destroy(gameObject);
        ScenesLoader.Instance.RestartLevel(reloadLevelDelay);
    }


    // Start is called before the first frame update
    void Start()
    {
        allowInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!allowInput)
        {
            return; //exit
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Vector3 newPosition = transform.position + new Vector3(0, 0, 1);
            Vector3 newPosition = transform.position + Vector3.forward;
            //transform.position = newPosition;
            MoveTo(newPosition);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 newPosition = transform.position + Vector3.back;
            MoveTo(newPosition);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 newPosition = transform.position + Vector3.left;
            MoveTo(newPosition);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 newPosition = transform.position + Vector3.right;
            MoveTo(newPosition);
        }

        
    }
    public void Fall()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;

        Invoke("Die", 1f);
        //Die();
    }
    void MoveTo(Vector3 newPosition)
    {
        if (Physics.Raycast(newPosition, Vector3.down, 1f))
        {
            LayerMask layerMask = LayerMask.GetMask("Block");
            if (!Physics.Raycast(newPosition, Vector3.down, 1f, layerMask))
            {
                allowInput = false;
                transform.DOJump(newPosition, jumpPower, 1, moveTime).OnComplete(ResetInput);
            }
        }
    }
    void ResetInput()
    {
        allowInput = true;
    }

}
