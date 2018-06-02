using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public Player PlayerInControl;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (PlayerInControl)
        {
            var movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
            var aim = new Vector2 (Input.GetAxis ("Aim X"), Input.GetAxis ("Aim Y")).normalized;
            PlayerInControl.Move (movement);
            PlayerInControl.Aim (aim);
        }
    }
}