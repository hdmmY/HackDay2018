using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (MeshRenderer))]
public class ConnectionLightScaleController : MonoBehaviour
{
    public float ScaleXFactor;

    private Material _connectLightMat;

    private void OnEnable ()
    {
        _connectLightMat = GetComponent<MeshRenderer> ().material;
    }

    private void Update ()
    {
        _connectLightMat.SetFloat ("_ScaleX", transform.localScale.x * ScaleXFactor);
    }

}