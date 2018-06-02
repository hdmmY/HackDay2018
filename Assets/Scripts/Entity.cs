using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public float MoveSpeed = 10;
    public float RotateSpeed = 600;
    public Vector2 LookAt;
    public GameObject TextureObject;

    public virtual void Move(Vector2 dir)
    {
        if (dir.magnitude > 1)
            dir = dir.normalized;
        transform.Translate(dir * MoveSpeed * Time.deltaTime, Space.World);
    }

    public virtual void Aim(Vector2 dir)
    {
        if (dir.magnitude == 0)
            return;
        LookAt = dir;
        var ang = -Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        var dAng = Mathf.Clamp(Utility.NormalizeAngle(ang - transform.rotation.eulerAngles.z), -RotateSpeed * Time.deltaTime, RotateSpeed * Time.deltaTime);
        //Debug.Log(transform.rotation.e);
        transform.Rotate(0, 0, dAng);
    }
}
