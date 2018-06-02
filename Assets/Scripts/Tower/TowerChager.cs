using UnityEngine;
using DynamicLight2D;

[RequireComponent (typeof (TowerProperty))]
public class TowerChager : MonoBehaviour
{
    public SpriteRenderer TowerRenderer;

    public DynamicLight TowerLight;

    private TowerProperty _tower;

    private float _towerRunningTime;

    private readonly float _ChargeFactor = 0.4f;

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
                towerColor.a = Mathf.Clamp01 (_towerRunningTime / 0.2f + +_ChargeFactor);
            }
            else
            {
                towerColor.a = 1.0f * _tower.CurPower / _tower.MaxPower;
            }
        }
        else
        {
            towerColor.a = _ChargeFactor * 1.0f * _tower.CurPower / _tower.MaxPower;
        }
        TowerRenderer.color = towerColor;

        // Update tower light intensity
        if (_tower.Running)
        {
            if (_tower.CurPower == _tower.MaxPower)
            {
                TowerLight.Intensity = (_towerRunningTime / 0.2f + _ChargeFactor) * _tower.MaxLightIntensity;
            }
            else
            {
                TowerLight.Intensity = 1.0f * _tower.CurPower / _tower.MaxPower * _tower.MaxLightIntensity;
            }
        }
        else
        {
            towerColor.a = _ChargeFactor * 1.0f * _tower.CurPower / _tower.MaxPower;
        }
    }
}