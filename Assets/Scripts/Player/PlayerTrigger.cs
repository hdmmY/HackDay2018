using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other)
    {
    }

    private void OnTriggerStay2D (Collider2D other)
    {
        if (other.CompareTag ("Tower"))
        {
            var charger = other.transform.GetComponentInParent<TowerChager> ();

            charger.Charge ();
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
    }
}