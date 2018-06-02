using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float XSpeed;

    public float YSpeed;

    private void Update ()
    {
        transform.position += new Vector3 (
            Input.GetAxis ("Horizontal") * XSpeed * Time.deltaTime,
            Input.GetAxis ("Vertical") * YSpeed * Time.deltaTime,
            0f
        );
    }
}