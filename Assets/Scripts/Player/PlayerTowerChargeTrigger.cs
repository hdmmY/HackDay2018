using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class PlayerTowerChargeTrigger : MonoBehaviour
{
    private void OnTriggerStay2D (Collider2D other)
    {
        if (other.CompareTag ("Tower"))
        {
            var tower = other.transform.GetComponentInParent<TowerProperty> ();
            var charger = tower.GetComponent<TowerChager> ();

            if (!tower.Running) charger.Charge ();
        }
    }
}