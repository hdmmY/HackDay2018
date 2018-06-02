using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    public Transform Target;

    public float SmoothTime = 1f;

    private Vector3 _velocity;

    private void Update ()
    {
        Vector3 targetPos = Target.position;
        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp (transform.position, targetPos,
            ref _velocity, SmoothTime, 10f, Time.deltaTime);
    }
}