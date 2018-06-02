using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public float HMoveSpeed;

    public float VMoveSpeed;

    public float AimSpeed;

    [Space]

    public float NormalShotInterval;

    public float NormalShotSpeed;

    public int NormalShotDamage;

    [Space]

    public int MaxManaPoint;

    public int CurManaPoint
    {
        get { return _curManaPoint; }
        set { _curManaPoint = Mathf.Clamp (_curManaPoint + value, 0, MaxManaPoint); }
    }

    [SerializeField] private int _curManaPoint;


    [Space]

    public float DetectRadius;




    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireSphere (transform.position, DetectRadius);
    }
}