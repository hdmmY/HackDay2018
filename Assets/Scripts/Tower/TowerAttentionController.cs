using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class TowerAttentionController : MonoBehaviour
{
    // Degrees per second
    public float RotateSpeed;

    public float UnRunningRadius;

    public float RunningRadius;

    public Color UnRunningColor;

    public Color RuningColor;


    private SpriteRenderer _spriteRenderer;

    private TowerProperty _tower;

    private float _towerRunningTimer;

    private void OnEnable ()
    {
        _tower = transform.GetComponentInParent<TowerProperty> ();
        _spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    private void Update ()
    {
        float rotSpeed = _tower.Running ? RotateSpeed * 0.2f : RotateSpeed;

        transform.Rotate (0, 0, rotSpeed * Time.deltaTime, Space.Self);

        if (!_tower.Running)
        {
            _towerRunningTimer = 0f;

            float alpha = _tower.CurPower / _tower.MaxPower;

            _spriteRenderer.color = new Color (
                UnRunningColor.r, UnRunningColor.g, UnRunningColor.b, alpha);
            transform.localScale = new Vector3 (UnRunningRadius, UnRunningRadius, 0f);
        }
        else
        {
            _towerRunningTimer += Time.deltaTime;

            _spriteRenderer.color = RuningColor;

            float scale = UnRunningRadius + Mathf.Clamp01 (_towerRunningTimer / 1f) * (RunningRadius - UnRunningRadius);

            transform.localScale = new Vector3 (scale, scale, 0f);
        }
    }

}