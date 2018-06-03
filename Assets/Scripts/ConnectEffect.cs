using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectEffect : MonoBehaviour
{
    public GameObject Begin;
    public GameObject End;
    public float Length { get { return (End.transform.position - Begin.transform.position).magnitude; } }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var dir = End.transform.position - Begin.transform.position;
        var pos = (Begin.transform.position + End.transform.position) / 2;
        transform.position = new Vector3(pos.x, pos.y, 1);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg);
        transform.localScale = new Vector3(Length, transform.localScale.y, 1);
    }
}
