using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public enum EnemyState
{
    Idle,
    Chase,
    Numb,
}
public class Enemy : Entity {
    public bool Visible = false;
    public StateMachine<EnemyState> StateMachine;
    private void Awake()
    {
        StateMachine = StateMachine<EnemyState>.Initialize(this, EnemyState.Idle);

    }
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Idle_Update()
    {
        var player = GameSystem.Instance.Player;
        var dist = (player.transform.position - transform.position).magnitude;
        if (dist > player.DetectRadius)
            return;
        var hits = Physics2D.RaycastAll(transform.position, GameSystem.Instance.Player.transform.position - transform.position, dist, 1 << 8);
        if (hits.Length < 0)
            StateMachine.ChangeState(EnemyState.Chase);
    }

    void Chase_Update()
    {
        
    }
}
