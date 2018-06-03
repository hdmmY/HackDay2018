﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LargeEnemy : Enemy
{
    public float AttackDistance = 10;
    public GameObject AttackTarget = null;
    public GameObject DetectTower()
    {
        var target = GameObject.FindGameObjectsWithTag("Tower").Where((tower) =>
        {
            var detectRadius = tower.GetComponent<TowerProperty>().LightRadius * 2;
            var dst = (tower.transform.position - transform.position).magnitude;
            return dst < detectRadius;
        }).OrderBy(tower => (tower.transform.position - transform.position).magnitude).FirstOrDefault();
        return target;
    }
    public override bool Detect()
    {
        return false;
    }
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Idle_Update()
    {
        if (AttackTarget = DetectTower())
            StateMachine.ChangeState(EnemyState.AttackTower);
    }

    void AttackTower_Update()
    {
        var dst = (AttackTarget.transform.position - transform.position).magnitude;
        if(dst>AttackDistance)
        {
            currentTargetSpeed = MaxSpeed;
            Move(AttackTarget.transform.position - transform.position);
            Aim(AttackTarget.transform.position - transform.position);
        }
        else
        {
            Debug.Log("ATTACK");
        }
    }

    protected override void Wander_Update()
    {
        base.Wander_Update();
        if (AttackTarget = DetectTower())
            StateMachine.ChangeState(EnemyState.AttackTower);
    }
}