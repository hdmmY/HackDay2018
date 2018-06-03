using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectEffect : MonoBehaviour
{
    public Vector2 Begin;
    public Vector2 End;
    public float Length { get { return (End - Begin).magnitude; } }

    // Use this for initialization
    void Start()
    {
        var dir = End - Begin;
        transform.position = Begin.ToVec3(1);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x));
        transform.localScale = new Vector3(Length, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
