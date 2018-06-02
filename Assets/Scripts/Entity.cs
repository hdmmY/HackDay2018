using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float MoveSpeed = 10;
    public float RotateSpeed = 600;
    public Vector2 LookAt;
    public GameObject TextureObject;

    private Vector3 _rotVelocity;

    public virtual void Move (Vector2 dir)
    {
        if (dir.magnitude > 1)
            dir = dir.normalized;
        transform.Translate (dir * MoveSpeed * Time.deltaTime, Space.World);
    }

    public virtual void Aim (Vector2 dir)
    {
        if (dir.magnitude == 0)
            return;

        LookAt = dir;

        float rowAngle = Utility.GetAngleFromTwoPosition (Vector3.zero, transform.up);
        float angle = Utility.GetAngleFromTwoPosition (Vector3.zero, dir);
        angle = Mathf.Lerp (angle, rowAngle, 0.7f);
        transform.rotation = Quaternion.Euler (0, 0, angle - 90f);
    }
}