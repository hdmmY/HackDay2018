using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector3 ToVec3(this Vector2 v, float z = 0)
    {
        return new Vector3(v.x, v.y, z);
    }
    
    public static float NormalizeAngle(float ang)
    {
        if(ang>0)
            ang -= Mathf.Floor((ang + Mathf.Sign(ang) * 180) / 360) * 360;
        if(ang <0)
            ang -= Mathf.Ceil((ang + Mathf.Sign(ang) * 180) / 360) * 360;
        return ang;
    }
}
