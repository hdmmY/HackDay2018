using UnityEngine;

[RequireComponent(typeof(PlayerProperty), typeof(PlayerShot), typeof(Rigidbody2D))]
public class Skill_AimShotter : MonoBehaviour
{
    public float HomeSpeed = 10f;

    private PlayerProperty _player;
    private PlayerShot _playerShotter;
    private Rigidbody2D _rig2D;

    private CircleCollider2D _trigger;
    private Detecter _detecter;

    private float _shotTimer;

    private void OnEnable()
    {
        _player = GetComponent<PlayerProperty>();
        _playerShotter = GetComponent<PlayerShot>();
        _rig2D = GetComponent<Rigidbody2D>();

        _trigger = new GameObject("Aim Detecter").AddComponent<CircleCollider2D>();
        _trigger.transform.parent = transform;
        _trigger.transform.position = transform.position;
        _trigger.radius = _player.DetectRadius;
        _trigger.gameObject.layer = LayerMask.NameToLayer("Background");
        _trigger.isTrigger = true;
        _detecter = _trigger.gameObject.AddComponent<Detecter>();

        _playerShotter.enabled = false;
    }

    private void OnDisable()
    {
        _playerShotter.enabled = true;
        Destroy(_trigger.gameObject);
    }

    private void Update ()
    {
        _trigger.radius = _player.DetectRadius;

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
        if(_detecter.Target != null)
        {
            moveCtrl.Homing = true;
            moveCtrl.HomeTarget = _detecter.Target;
            moveCtrl.HomeAngleSpeed = HomeSpeed;
            moveCtrl.MaxHomeAngle = 10000000;
            Debug.Log(moveCtrl.HomeTarget.name);
        }
    }

    private class Detecter : MonoBehaviour
    {
        public Transform Target;

        private void OnTriggerStay2D(Collider2D other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Target = other.transform;
            }
        }
    }
}