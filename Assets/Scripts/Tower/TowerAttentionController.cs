using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class TowerAttentionController : MonoBehaviour
{
    // Degrees per second
    public float RotateSpeed;

    private SpriteRenderer _spriteRenderer;

    private TowerProperty _tower;

    private void OnEnable ()
    {
        _tower = transform.GetComponentInParent<TowerProperty> ();
        _spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    private void Update ()
    {
        _spriteRenderer.enabled = !_tower.Running;

        transform.Rotate (0, 0, RotateSpeed * Time.deltaTime, Space.Self);
    }

}