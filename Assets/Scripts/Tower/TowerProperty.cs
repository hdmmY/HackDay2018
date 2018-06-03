using UnityEngine;

public class TowerProperty : MonoBehaviour
{
    public float MaxLightRadius;

    public float CurPower;

    public float MaxPower;

    public float LightRadius
    {
        get
        {
            return Running ? CurPower / MaxPower * 7.82f : 0f;
        }
    }


    public bool Running;

    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireSphere (transform.position, LightRadius);
    }
}