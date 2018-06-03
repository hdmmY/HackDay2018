using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectManager : Singleton<ConnectManager>
{
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
        GameObject key = null;
        if (ConnectionMap.ContainsKey(start))
            key = start;
        else if (ConnectionMap.ContainsKey(end))
            key = end;
        if (key == null)
            key = start;
        if(!ConnectionMap.ContainsKey(key))
        {

        }
    }
}