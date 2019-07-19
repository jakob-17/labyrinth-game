using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // run right after Update()
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
