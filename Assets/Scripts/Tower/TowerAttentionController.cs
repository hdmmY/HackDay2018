using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class TowerAttentionController : MonoBehaviour
{
    // Degrees per second
    public float RotateSpeed;

    public Color UnRunningColor;

    public Color RuningColor;



    private SpriteRenderer _spriteRenderer;

    private TowerProperty _tower;

    private void OnEnable ()
    {
        _tower = transform.GetComponentInParent<TowerProperty> ();
        _spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    private void Update ()
    {        
        transform.Rotate (0, 0, RotateSpeed * Time.deltaTime, Space.Self);
    
        // if()
    
    }

}