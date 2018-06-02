using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (PlayerProperty))]
public class PlayerAim : MonoBehaviour
{
    private PlayerProperty _player;
    private PlayerMove _playerMove;
    private Rigidbody2D _rig2D;

    private float _lastX, _lastY;

    private float _lastValidX, _lastValidY;

    private void OnEnable ()
    {
        _player = GetComponent<PlayerProperty> ();
        _playerMove = GetComponent<PlayerMove> ();
        _rig2D = GetComponent<Rigidbody2D> ();
    }

    private void Update ()
    {
        float x = Input.GetAxis ("Aim X");
        float y = Input.GetAxis ("Aim Y");

        if (Mathf.Abs (x) <= 0.1f && Mathf.Abs (y) <= 0.1f)
        {
            if (_playerMove.Speed.magnitude < 0.5f)
            {
                x = _lastValidX;
                y = _lastValidY;
            }
            else
            {
                Vector2 dir = _playerMove.Speed.normalized;
                x = dir.x;
                y = dir.y;
            }
        }

        float deltX, deltY;

        if (_lastX < x)
        {
            deltX = Mathf.Clamp (Time.deltaTime * _player.HAimSpeed, 0, x - _lastX);
        }
        else
        {
            deltX = Mathf.Clamp (-Time.deltaTime * _player.HAimSpeed, x - _lastX, 0);
        }

        if (_lastY < y)
        {
            deltY = Mathf.Clamp (Time.deltaTime * _player.VAimSpeed, 0, y - _lastY);
        }
        else
        {
            deltY = Mathf.Clamp (-Time.deltaTime * _player.VAimSpeed, y - _lastY, 0);
        }

        if (Mathf.Abs (deltX) > 0.2f) x += deltX;
        if (Mathf.Abs (deltY) > 0.2f) y += deltY;

        float angle = Utility.GetAngleFromTwoPosition (Vector2.zero, new Vector2 (x, y));

        _rig2D.rotation = angle - 90f;

        _lastX = x;
        _lastY = y;

        if (Mathf.Abs (_lastX) > 0.1f) _lastValidX = _lastX;
        if (Mathf.Abs (_lastY) > 0.1f) _lastValidY = _lastY;
    }
}