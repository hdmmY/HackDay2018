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

    //public float Power = 160;

    [Space]

    public float MaxManaPoint;

    public float Power
    {
        get { return CurrentPower; }
        set { CurrentPower = Mathf.Clamp (value, 0, MaxManaPoint); }
    }

    [SerializeField] public float CurrentPower;


    [Space]

    public float DetectRadius;




    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireSphere (transform.position, DetectRadius);
    }
}