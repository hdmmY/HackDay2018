using UnityEngine;
using DynamicLight2D;

[ExecuteInEditMode]
[RequireComponent (typeof (TowerProperty))]
public class TowerChager : MonoBehaviour
{
    public SpriteRenderer TowerRenderer;

    public DynamicLight TowerLight;

    public float ChargeSpeed;
    public bool isCharging = false;

    public void Charge ()
    {
        var charge = Time.deltaTime * ChargeSpeed;
        charge = Mathf.Clamp(charge, 0, GameManager.Instance.Player.GetComponent<PlayerProperty>().Power);
        GameManager.Instance.Player.GetComponent<PlayerProperty>().Power -= charge;
        float power = _tower.CurPower + charge;
        
        _tower.CurPower = Mathf.Clamp (power, 0, _tower.MaxPower);

        if (_tower.MaxPower < power + 0.01f)
        {
            _tower.Running = true;
        }
        else
        {
            _tower.Running = false;
        }
    }

    private TowerProperty _tower;

    private float _towerRunningTime;

    private readonly float _MinSpriteAlpha = 0.1f;
    private readonly float _SpriteChargeFactor = 0.1f;

    private readonly float _LightChargeFactor = 5f;

    private void OnEnable ()
    {
        _tower = GetComponent<TowerProperty> ();
        _towerRunningTime = 0f;
    }

    private void Update ()
    {
        if (_tower.Running)
        {
            _towerRunningTime += Time.deltaTime;
        }
        else
        {
            _towerRunningTime = 0f;
        }


        // Update tower sprite 
        Color towerColor = TowerRenderer.color;
        if (_tower.Running)
        {
            if (_tower.CurPower == _tower.MaxPower)
            {
                towerColor.a = Mathf.Clamp01 (_MinSpriteAlpha + _towerRunningTime / 1f + _SpriteChargeFactor);
            }
            else
            {
                towerColor.a = Mathf.Clamp (1.0f * _tower.CurPower / _tower.MaxPower, _MinSpriteAlpha, 1f);
            }
        }
        else
        {
            towerColor.a = _MinSpriteAlpha + _SpriteChargeFactor * 1.0f * _tower.CurPower / _tower.MaxPower;
        }
        TowerRenderer.color = towerColor;

        // Update tower light intensity
        if (_tower.Running)
        {
            if (_tower.CurPower == _tower.MaxPower)
            {
                TowerLight.LightRadius = Mathf.Clamp01 (_towerRunningTime / 1f + _LightChargeFactor / _tower.MaxLightRadius) * _tower.MaxLightRadius;
            }
            else
            {
                TowerLight.LightRadius = 1.0f * _tower.CurPower / _tower.MaxPower * _tower.MaxLightRadius;
            }
        }
        else
        {
            TowerLight.LightRadius = _LightChargeFactor * 1.0f * _tower.CurPower / _tower.MaxPower;
        }
    }
}