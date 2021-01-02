using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    Vector3 offset;

    void Awake()
    {
        Initialize();
    }

    void LateUpdate()
    {
        FollowTarget();
    }

    void Initialize()
    {
        if (target == null) {
            Debug.LogError("Cannot found target...");
        }

        offset = (transform.position - target.position);
    }

    void FollowTarget()
    {
        Vector3 result = (target.position + offset);
        transform.position = Vector3.Lerp(transform.position, result, 0.1f);
    }
}

