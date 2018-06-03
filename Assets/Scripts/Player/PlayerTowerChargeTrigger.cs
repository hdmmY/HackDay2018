using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class PlayerTowerChargeTrigger : MonoBehaviour
{
    private PlayerProperty _player;

    private void OnEnable()
    {
        _player = GetComponentInParent<PlayerProperty>();
    }

    bool isCharging = false;
    private void OnTriggerStay2D (Collider2D other)
    {
        var tower = other.transform.GetComponentInParent<TowerProperty>();
        if (tower != null)
        {
            var charger = tower.GetComponent<TowerChager> ();

            if (!tower.Running || (tower.CurPower != tower.MaxPower && _player.Power > 0))
            {
                charger.Charge();
                isCharging = true;
                ConnectManager.Instance.Connect(_player.gameObject, tower.gameObject);
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
        var tower = collision.transform.GetComponentInParent<TowerProperty>();
        if (tower != null)
        {
            ConnectManager.Instance.Disconnect(GameManager.Instance.Player, tower.gameObject);
        }
    }
}