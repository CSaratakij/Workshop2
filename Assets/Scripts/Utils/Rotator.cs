using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;

    [SerializeField]
    Vector3 rotateAxis = new Vector3(0, 1, 0);

    void LateUpdate()
    {
        RotateHandler();
    }

    void RotateHandler()
    {
        transform.Rotate(rotateAxis, rotateSpeed * Time.deltaTime);
    }
}
