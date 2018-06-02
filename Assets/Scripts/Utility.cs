using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector3 ToVec3 (this Vector2 v, float z = 0)
    {
        return new Vector3 (v.x, v.y, z);
    }

    public static float NormalizeAngle (float ang)
    {
        if (ang > 0)
            ang -= Mathf.Floor ((ang + Mathf.Sign (ang) * 180) / 360) * 360;
        if (ang < 0)
            ang -= Mathf.Ceil ((ang + Mathf.Sign (ang) * 180) / 360) * 360;
        return ang;
    }

    public static float GetAngleFromTwoPosition (Vector2 fromPos, Vector2 toPos)
    {
        var angle = Vector2.SignedAngle (Vector2.right, toPos - fromPos);

        return Get360Angle (angle);
    }

    /// <summary>
    /// Get 0 to 360 angle.
    /// </summary>
    public static float Get360Angle (float angle)
    {
        while (angle < 0f)
        {
            angle += 360f;
        }
        while (360f < angle)
        {
            angle -= 360f;
        }
        return angle;
    }
}