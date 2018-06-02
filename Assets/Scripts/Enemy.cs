using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public enum EnemyState
{
    Idle,
    Trace,
    Numb,
}
public class Enemy : Entity {

    private void Awake()
    {
        StateMachine<EnemyState>.Initialize(this, EnemyState.Idle);

    }
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Idle_Update()
    {

    }
}
