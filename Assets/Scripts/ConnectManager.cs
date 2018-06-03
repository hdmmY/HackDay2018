using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectManager : Singleton<ConnectManager>
{
    public GameObject Prefab;
    public Dictionary<GameObject, Dictionary<GameObject, GameObject>> ConnectionMap = new Dictionary<GameObject, System.Collections.Generic.Dictionary<GameObject, GameObject>>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Connect(GameObject start, GameObject end)
    {
        GameObject keyA = null, keyB = null;
        if (ConnectionMap.ContainsKey(start))
        {
            keyA = start;
            keyB = end;
        }
        else if (ConnectionMap.ContainsKey(end))
        {
            keyA = end;
            keyB = start;
        }
        if (keyA == null)
        {
            keyA = start;
            keyB = end;
        }
        if(!ConnectionMap.ContainsKey(keyA))
        {
            ConnectionMap[keyA] = new Dictionary<GameObject, GameObject>();
        }
        if(ConnectionMap[keyA].ContainsKey(keyB))
        {
            return;
        }
        var obj = Instantiate(Prefab);
        obj.GetComponent<ConnectEffect>().Begin = start;
        obj.GetComponent<ConnectEffect>().End = end;
        ConnectionMap[keyA][keyB] = obj;
    }

    public void Disconnect(GameObject start,GameObject end)
    {
        GameObject keyA = null, keyB = null;
        if (ConnectionMap.ContainsKey(start))
        {
            keyA = start;
            keyB = end;
        }
        else if (ConnectionMap.ContainsKey(end))
        {
            keyA = end;
            keyB = start;
        }
        if (keyA == null)
        {
            keyA = start;
            keyB = end;
        }
        if (!ConnectionMap.ContainsKey(keyA))
        {
            return;
        }

        Destroy(ConnectionMap[keyA][keyB]);
        ConnectionMap[keyA].Remove(keyB);
    }
}