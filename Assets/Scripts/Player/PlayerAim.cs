using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (PlayerProperty))]
public class PlayerAim : MonoBehaviour
{
    private PlayerProperty _player;
    private PlayerMove _playerMove;
    private Rigidbody2D _rig2D;

    private float _lastX, _lastY;

    private void OnEnable ()
    {
        _player = GetComponent<PlayerProperty> ();
        _playerMove = GetComponent<PlayerMove> ();
        _rig2D = GetComponent<Rigidbody2D> ();
    }

    private void FixedUpdate ()
    {
        float x = Input.GetAxis ("Aim X");
        float y = Input.GetAxis ("Aim Y");

        float angle;

        if (Mathf.Abs (x) < 0.5f && Mathf.Abs (y) < 0.5f)
        {
            if (_playerMove.Speed.magnitude < 3.0f)
            {
                return;
            }
            else
            {
                angle = Utility.GetAngleFromDirection (_playerMove.Speed);
            }
        }
        else
        {
            angle = Utility.GetAngleFromDirection (new Vector2 (x, y));
        }

        angle = Mathf.MoveTowardsAngle (_rig2D.rotation + 90f, angle, Time.deltaTime * _player.AimSpeed);

        _rig2D.rotation = angle - 90f;
    }
}