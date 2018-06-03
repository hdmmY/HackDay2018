using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class PlayerTowerChargeTrigger : MonoBehaviour
{
    bool isCharging = false;
    private void OnTriggerStay2D (Collider2D other)
    {
        if (other.CompareTag ("Tower"))
        {
            var tower = other.transform.GetComponentInParent<TowerProperty> ();
            var charger = tower.GetComponent<TowerChager> ();

            if (!tower.Running)
            {
                charger.Charge();
                isCharging = true;
                ConnectManager.Instance.Connect(GameManager.Instance.Player, tower.gameObject);
            }
            else if(isCharging)
            {
                isCharging = false;
                ConnectManager.Instance.Disconnect(GameManager.Instance.Player, tower.gameObject);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Tower"))
        {
            var tower = collision.transform.GetComponentInParent<TowerProperty>();
            ConnectManager.Instance.Disconnect(GameManager.Instance.Player, tower.gameObject);
        }
    }
}