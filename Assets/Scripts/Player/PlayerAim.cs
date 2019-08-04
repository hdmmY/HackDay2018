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

    private bool useJoystick = false;

    private void OnEnable ()
    {
        _player = GetComponent<PlayerProperty> ();
        _playerMove = GetComponent<PlayerMove> ();
        _rig2D = GetComponent<Rigidbody2D> ();
    }

    private void FixedUpdate ()
    {
        var mouseDir = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).ToVector2() - _player.transform.position.ToVector2();
        var joystickDir = new Vector2(Input.GetAxis("Aim X"), Input.GetAxis("Aim Y"));
        var mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 dir;
        if (mouseMovement.x != 0 || mouseMovement.y != 0)
            useJoystick = false;
        else if (joystickDir.x != 0 || joystickDir.y != 0)
        {
            useJoystick = true;
        }

        if (useJoystick)
            dir = joystickDir;
        else
            dir = mouseDir;

        float x = dir.x; //Input.GetAxis ("Aim X");
        float y = dir.y;// Input.GetAxis ("Aim Y");

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