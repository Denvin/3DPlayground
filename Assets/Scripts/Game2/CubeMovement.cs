using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public class CubeMovement : MonoBehaviour
{
    public GameObject destroyFX;
    public GameObject portalFX;

    [SerializeField] float moveTime = 0.5f;
    [SerializeField] float jumpPower = 1f;
    [SerializeField] float timeTeleport = 1f;

    [Header("Sounds")]
    [SerializeField] AudioClip deathSound;



    bool allowInput;

    
    
    public void Die()
    {
        Vector3 fxPosition = transform.position;
        
        if (destroyFX != null)
        {
            Instantiate(destroyFX, fxPosition, Quaternion.identity);
        }
        AudioManager.Instance.PlaySound(deathSound);
        Destroy(gameObject);
        ScenesLoader.Instance.RestartLevel();
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
            MoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBack();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }


    }

    public void MoveRight()
    {

        Vector3 newPosition = transform.position + Vector3.right;
        MoveTo(newPosition);
        ResetInput();
    }

    public void MoveLeft()
    {
        Vector3 newPosition = transform.position + Vector3.left;
        MoveTo(newPosition);
    }

    public void MoveBack()
    {
        Vector3 newPosition = transform.position + Vector3.back;
        MoveTo(newPosition);
    }

    public void MoveForward()
    {
        Vector3 newPosition = transform.position + Vector3.forward;
        MoveTo(newPosition);
    }

    public void Fall()
    {
        allowInput = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;


        StartCoroutine(FallCoroutine());
    }

    /*public void Teleport(Vector3 endPosition)
    {
        Vector3 nextPosition = new Vector3(0,2,0) + transform.position;
        Sequence movementSequance = DOTween.Sequence();
        movementSequance.Append(transform.DOMove(nextPosition, timeTeleport))
            .Append(transform.DOMove(endPosition, timeTeleport)); 
    }*/
    public void Teleport(Vector3 endPosition)
    {
        StartCoroutine(TeleportCoroutine(endPosition));
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

    IEnumerator TeleportCoroutine(Vector3 endPosition)
    {
        Vector3 fxPosition = transform.position;
        if (portalFX != null)
        {
            Instantiate(portalFX, transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(timeTeleport);
        transform.position = endPosition;
    }

    IEnumerator FallCoroutine()
    {   
        yield return new WaitForSeconds(1.5f);
        Die();
    }
}
