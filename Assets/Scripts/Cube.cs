using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MeshRenderer ballRenderer = collision.gameObject.GetComponent<MeshRenderer>();
            Material ballMaterial = ballRenderer.material;

            renderer.material.color = ballMaterial.color;
        }
    }
}
