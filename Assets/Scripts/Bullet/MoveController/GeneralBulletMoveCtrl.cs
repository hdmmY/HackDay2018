using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBulletMoveCtrl : BaseBulletMoveCtrl
{
    public float Angle = 90f;
    public float Speed = 0f;
    public float Accelerate = 0f;
    public float AngleSpeed = 0f;
    public float AngleAccel = 0f;

    [Space]
    public bool Homing = false;
    public Transform HomeTarget = null;
    public float HomeAngleSpeed = 0f;
    public float MaxHomeAngle = 0f;

    [Space]
    public bool Pause = false;
    public float PauseTime = 0f;
    public float ResumeTime = 0f;

    public override void Init ()
    {
        _angle = Angle - 90f;
        _homeAngle = 0f;
        _selfTimeCount = 0f;

        transform.rotation = Quaternion.Euler (0, 0, _angle);

        _initialized = true;
    }

    #region  Private Variables and Methods
    private float _angle;
    private float _homeAngle;
    private float _selfTimeCount;
    private bool _initialized;

    private void OnDisable ()
    {
        _initialized = false;
    }

    private void Update ()
    {
        if (!_initialized) return;

        _bulletMove.Speed = Speed;
        _bulletMove.Accelerate = Accelerate;
        _selfTimeCount += Time.deltaTime;

        if (Homing)
        {
            if (HomeTarget != null && HomeAngleSpeed > 0)
            {
                float rotateAngle = Utility.GetAngleFromTwoPosition (transform.position, HomeTarget.position) - 90;
                float myAngle = transform.eulerAngles.z;
                float toAngle = Mathf.MoveTowardsAngle (myAngle, rotateAngle,
                    Time.deltaTime * HomeAngleSpeed);
                float angleSpeed = Time.deltaTime == 0f ? 0f :
                    Mathf.Abs (toAngle - myAngle) / Time.deltaTime;

                _homeAngle += angleSpeed * Time.deltaTime;
                if (_homeAngle <= MaxHomeAngle)
                {
                    _bulletMove.AngleSpeed = angleSpeed;
                }
            }
            else
            {
                _bulletMove.AngleSpeed = 0f;
            }
        }
        else
        {
            _bulletMove.AngleSpeed = AngleSpeed;
        }

        if (Pause && PauseTime > 0 && ResumeTime > PauseTime)
        {
            if (PauseTime < _selfTimeCount && _selfTimeCount < ResumeTime)
            {
                _bulletMove.Stop = true;
            }
            else
            {
                _bulletMove.Stop = false;
            }
        }
    }

    #endregion
}