using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (BulletProperty))]
public class BulletMovement : MonoBehaviour
{
    #region Public properties and methods

    /// <summary>
    /// Stop the movement
    /// </summary>
    public bool Stop
    {
        get { return _stop; }
        set { _stop = value; }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public float Accelerate
    {
        get { return _accel; }
        set { _accel = value; }
    }

    public float AngleSpeed
    {
        get { return _angleSpeed; }
        set { _angleSpeed = value; }
    }

    public float AngleAccelerate
    {
        get { return _angleAccel; }
        set { _angleAccel = value; }
    }

    #endregion

    #region Private variables

    [SerializeField] private bool _stop = false;
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _accel = 0f;
    [SerializeField] private float _angleSpeed = 0f;
    [SerializeField] private float _angleAccel = 0f;

    #endregion

    #region Monobehavior

    private void LateUpdate ()
    {
        float deltTime = Time.deltaTime;

        if (Stop) return;

        _speed += Accelerate * deltTime;
        _angleSpeed += AngleAccelerate * deltTime;

        Vector3 rot = transform.rotation.eulerAngles;
        rot.z += AngleSpeed * deltTime;
        transform.rotation = Quaternion.Euler (rot);

        transform.position += transform.up * Speed * deltTime;
    }

    #endregion
}