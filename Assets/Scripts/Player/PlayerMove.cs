using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerProperty))]
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    public Vector2 Speed { get; private set; }

    public Vector2 LastVaildSpeed { get; private set; }

    private PlayerProperty _playerProperty;
    private Rigidbody2D _rig2D;

    private void OnEnable ()
    {
        _playerProperty = GetComponent<PlayerProperty> ();
        _rig2D = GetComponent<Rigidbody2D> ();
    }

    private void Update ()
    {
        float x = _playerProperty.HMoveSpeed * Input.GetAxis ("Horizontal");
        float y = _playerProperty.VMoveSpeed * Input.GetAxis ("Vertical");

        LastVaildSpeed = Speed.magnitude < 1f ? LastVaildSpeed : Speed;
        Speed = new Vector2 (x, y);

        _rig2D.position += new Vector2 (x, y) * Time.deltaTime;

    }

}