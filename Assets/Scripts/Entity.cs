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

        float rowAngle = Utility.GetAngleFromTwoPosition (Vector3.zero, transform.up);
        float angle = Utility.GetAngleFromTwoPosition (Vector3.zero, dir);
        rowAngle += Mathf.Clamp(Utility.NormalizeAngle(angle - rowAngle), -RotateSpeed * Time.deltaTime, RotateSpeed * Time.deltaTime);
        LookAt = new Vector2(Mathf.Cos(rowAngle * Mathf.Deg2Rad), Mathf.Sin(rowAngle * Mathf.Deg2Rad));
        transform.rotation = Quaternion.Euler (0, 0, rowAngle - 90f);
    }
}