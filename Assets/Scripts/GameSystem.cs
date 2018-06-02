using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameSystem : Singleton<GameSystem>
{
    public Player Player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            if (PlayerController.Instance)
                PlayerController.Instance.PlayerInControl = Player;
        }
    }
}