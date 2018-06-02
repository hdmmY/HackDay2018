using UnityEngine;
using DynamicLight2D;

[RequireComponent (typeof (DynamicLight))]
[ExecuteInEditMode]
public class SyncOccludeLight : MonoBehaviour
{
    public DynamicLight SourceLight;

    private DynamicLight _originLight;

    private void OnEnable ()
    {
        _originLight = GetComponent<DynamicLight> ();
    }

    private void Update ()
    {
        if (SourceLight != null && _originLight != null)
        {
            _originLight.LightRadius = SourceLight.LightRadius;
        }
    }

}