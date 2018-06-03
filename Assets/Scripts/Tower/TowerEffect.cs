using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEffect : MonoBehaviour
{
    bool connected = false;
    // Update is called once per frame
    void Update()
    {
        var player = GameManager.Instance.Player;
        var dst = (player.transform.position - transform.position).magnitude;
        if (dst <= GetComponent<TowerProperty>().LightRadius)
        {
            ConnectManager.Instance.Connect(GameManager.Instance.Player, gameObject);
            connected = true;
            ApplyEffect();
        }
        else if(connected)
        {
            connected = false;
            ConnectManager.Instance.Disconnect(GameManager.Instance.Player, gameObject);
        }
    }

    public virtual void ApplyEffect()
    {

    }
}
