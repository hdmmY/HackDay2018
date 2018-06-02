using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcontroller : MonoBehaviour
{
    private void OnDrawGizmos ()
    {
        Vector3 bgCenter = transform.position + new Vector3 (0, 0, -1);
        Color bgColor = Color.red;

        Vector3 joystick = transform.position + new Vector3 (0, 0, -20);
        Color joystickColor = Color.black;

        Gizmos.color = bgColor;
        Gizmos.DrawCube (bgCenter, new Vector3 (20, 20, 0));

        Gizmos.color = joystickColor;
        Gizmos.DrawSphere (
            joystick + new Vector3 (Input.GetAxis ("Aim X"), Input.GetAxis ("Aim Y")) * 10f,
            1
        );
    }

}