using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class PlayerMonaPotionTrigger : MonoBehaviour
{
    private Transform _player;

    private void OnEnable ()
    {
        _player = GetComponentInParent<PlayerProperty> ().transform;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag ("ManaPotion"))
        {
            var chaser = other.gameObject.AddComponent<ManaPotionMoveCtrl> ();
            chaser.Target = _player;
        }
    }
}