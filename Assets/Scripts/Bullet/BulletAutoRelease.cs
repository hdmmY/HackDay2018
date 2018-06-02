using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BulletProperty))]
public class BulletAutoRelease : MonoBehaviour
{
    public float AutoReleaseTime = 10f;

    private float _timer;



    private void Update ()
    {
        _timer += Time.deltaTime;

        if (_timer > AutoReleaseTime)
        {
            Destroy (this.gameObject);
        }
    }
}