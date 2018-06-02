using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float Light = 0;
    public float Energy = 10;
    public float LightRadius = 1;
    public float DetectRadius = 1;
    public float StaticDetect = 0.8f;
    public bool Moving = false;

    void Update()
    {
        DetectRadius = Light;
        if(!Moving)
        {
            DetectRadius *= StaticDetect;
        }
    }

    public override void Move(Vector2 dir)
    {

        base.Move(dir);
    }
}
