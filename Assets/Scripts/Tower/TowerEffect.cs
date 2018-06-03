using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEffect : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var player = GameManager.Instance.Player;
        var dst = (player.transform.position - transform.position).magnitude;
        if (dst <= GetComponent<TowerProperty>().LightRadius)
        {

        }
    }
}
