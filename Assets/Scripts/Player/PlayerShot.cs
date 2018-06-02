using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerProperty))]
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerShot : MonoBehaviour
{
    #region Public Variables

    public BulletProperty PlayerBulletPrefab;

    #endregion

    #region Monobehavior

    private void OnEnable ()
    {
        _player = GetComponent<PlayerProperty> ();
        _rig2D = GetComponent<Rigidbody2D> ();
        _shotTimer = 0f;
    }

    private void Update ()
    {
        if (Input.GetAxis ("Fire1") < -0.5f)
        {
            _shotTimer += Time.deltaTime;

            if (_shotTimer > _player.NormalShotInterval)
            {
                _shotTimer = 0f;

                Vector3 shotPos = transform.position + transform.up * 0.15f;
                var shotRot = PlayerBulletPrefab.transform.rotation;

                var bullet = Instantiate (PlayerBulletPrefab, shotPos, shotRot);
                bullet.Damage = _player.NormalShotDamage;
                var moveCtrl = bullet.gameObject.AddComponent<GeneralBulletMoveCtrl> ();
                moveCtrl.Speed = _player.NormalShotSpeed;
                moveCtrl.Angle = _rig2D.rotation + 90f;
                moveCtrl.Init ();
            }
        }
    }

    #endregion


    #region Private Variables 

    private PlayerProperty _player;
    private Rigidbody2D _rig2D;
    private float _shotTimer;

    #endregion

}