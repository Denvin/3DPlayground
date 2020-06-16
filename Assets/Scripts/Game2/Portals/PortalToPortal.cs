using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToPortal : MonoBehaviour
{
    [SerializeField] float waitActivePortal = 3f;
    [SerializeField] GameObject outputPortal;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(activePortal());
        CubeMovement cube = other.GetComponent<CubeMovement>();
        cube.Teleport(outputPortal.transform.position);
    }

    IEnumerator activePortal()
    {
        outputPortal.SetActive(false);

        yield return new WaitForSeconds(waitActivePortal);
        outputPortal.SetActive(true);
    }
}
