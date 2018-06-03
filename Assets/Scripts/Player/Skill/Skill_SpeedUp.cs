using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerProperty))]
public class Skill_SpeedUp : MonoBehaviour
{
    public float OverrideHMoveSpeed;

    public float OverrideVMoveSpeed;

    private PlayerProperty _player;

    private void OnEnable ()
    {
        _player = GetComponent<PlayerProperty> ();
    }

    private void Update ()
    {
        _player.HMoveSpeed = OverrideHMoveSpeed;
        _player.VMoveSpeed = OverrideVMoveSpeed;
    }

}