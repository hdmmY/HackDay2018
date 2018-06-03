using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLightColliderController : MonoBehaviour
{
    private TowerProperty _tower;

    private void OnEnable ()
    {
        _tower = GetComponentInParent<TowerProperty> ();
    }

    private void Update ()
    {
        gameObject.SetActive (!_tower.Running);
    }
}