using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3(-10, 8, -10);
    [SerializeField] float delay = 3.5f;

    [SerializeField] GameObject cube;



    // Update is called once per frame
    void FixedUpdate()
    {
        if (cube != null)
        {
            transform.position = Vector3.Lerp(transform.position, cube.transform.position + offset, delay * Time.deltaTime);
        }
    }
}
