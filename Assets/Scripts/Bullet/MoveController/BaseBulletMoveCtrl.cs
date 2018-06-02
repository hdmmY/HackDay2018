using UnityEngine;

[RequireComponent (typeof (BulletMovement), typeof (BulletProperty))]
public abstract class BaseBulletMoveCtrl : MonoBehaviour
{
    protected BulletProperty _bullet;

    protected BulletMovement _bulletMove;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    protected void Awake ()
    {
        _bullet = GetComponent<BulletProperty> ();
        _bulletMove = GetComponent<BulletMovement> ();
    }

    public abstract void Init ();
}