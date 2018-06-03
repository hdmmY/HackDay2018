using UnityEngine;

public class TowerProperty : MonoBehaviour
{
    public float MaxLightRadius;

    public float CurPower
    {
        get { return _curPower; }
        set { _curPower = Mathf.Clamp(value, 0, 100000); }
    }

    public float MaxPower;

    public float LightRadius
    {
        get
        {
            return Running ? CurPower / MaxPower * 7.82f : 0f;
        }
    }

    public bool Running;

    [SerializeField] private float _curPower;

    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireSphere (transform.position, LightRadius);
    }
}