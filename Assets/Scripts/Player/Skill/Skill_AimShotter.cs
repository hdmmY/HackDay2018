using UnityEngine;

[RequireComponent(typeof(PlayerProperty), typeof(PlayerShot), typeof(Rigidbody2D))]
public class Skill_AimShotter : MonoBehaviour
{
    public float HomeSpeed = 10f;

    private PlayerProperty _player;
    private PlayerShot _playerShotter;
    private Rigidbody2D _rig2D;

    private float _shotTimer;

    private void OnEnable()
    {
        _player = GetComponent<PlayerProperty>();
        _playerShotter = GetComponent<PlayerShot>();
        _rig2D = GetComponent<Rigidbody2D>();
    }

    private void Update ()
    {
        if (Input.GetAxis ("Fire1") < -0.5f)
        {
            _shotTimer += Time.deltaTime;

            if (_shotTimer > _player.NormalShotInterval)
            {
                _shotTimer = 0f;

                Vector3 shotPos = transform.position + transform.up * 0.25f;
                var shotRot = _playerShotter.PlayerBulletPrefab.transform.rotation;

                var bullet = Instantiate (_playerShotter.PlayerBulletPrefab, shotPos, shotRot);
                bullet.Damage = _player.NormalShotDamage;
                var moveCtrl = bullet.gameObject.AddComponent<GeneralBulletMoveCtrl> ();
                moveCtrl.Speed = _player.NormalShotSpeed;
                moveCtrl.Angle = _rig2D.rotation + 90f;
                Homing (moveCtrl);
                moveCtrl.Init ();
            }
        }
    }

    private void Homing (GeneralBulletMoveCtrl moveCtrl)
    {
        var hitted = Physics2D.CircleCastAll(transform.position, _player.DetectRadius, Vector3.zero, 0, 10);

        if(hitted != null && hitted.Length != 0)
        {
            moveCtrl.Homing = true;
            moveCtrl.HomeTarget = hitted[0].transform;
            moveCtrl.HomeAngleSpeed = HomeSpeed;
            moveCtrl.MaxHomeAngle = 10000000;
        }
    }
}