﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public float HMoveSpeed;

    public float VMoveSpeed;

    public float HAimSpeed;

    public float VAimSpeed;

    public float DetectRadius;


    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireSphere (transform.position, DetectRadius);
    }
}