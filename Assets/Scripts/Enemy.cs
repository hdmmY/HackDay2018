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
    public bool Rest = true;
    public bool Lighted = false;
    public Material RestMaterial;
    public Material ActiveMateiral;
    public StateMachine<EnemyState> StateMachine;
    public float NumbTime = 1;
    public float Acceleration = 1;
    public float MaxSpeed = 5;
    public float MaxRotateSpeed = 600;
    public float MinRotateSpeed = 160;
    float numbTime = 0;

    private void Awake()
    {
        StateMachine = StateMachine<EnemyState>.Initialize(this, EnemyState.Idle);
        MoveSpeed = 0;
    }
    // Use this for initialization
    void Start () {
	}

    public override void Move(Vector2 dir)
    {
        if(dir.magnitude>0)
        {
            MoveSpeed = Mathf.Clamp(MoveSpeed + Acceleration * Time.deltaTime, 0, MaxSpeed);
        }
        else
        {
            MoveSpeed = 0;
        }
        base.Move(dir);
    }
    // Update is called once per frame
    void Update()
    {
        RotateSpeed = -((MaxRotateSpeed - MinRotateSpeed)/MaxSpeed) * MoveSpeed + MaxRotateSpeed;
        if (Rest)
        {
            TextureObject.GetComponent<SpriteRenderer>().material = RestMaterial;
        }
        else
        {   
            TextureObject.GetComponent<SpriteRenderer>().material = ActiveMateiral;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && StateMachine.State == EnemyState.Chase)
            StateMachine.ChangeState(EnemyState.Numb);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && StateMachine.State == EnemyState.Chase)
            StateMachine.ChangeState(EnemyState.Numb);
    }

    void Idle_Update()
    {
        var player = GameSystem.Instance.Player;
        var dist = (player.transform.position - transform.position).magnitude;
        if (dist > player.DetectRadius)
            return;
        var hits = Physics2D.RaycastAll(transform.position, GameSystem.Instance.Player.transform.position - transform.position, dist, 1 << 8);
        if (hits.Length <= 0)
            StateMachine.ChangeState(EnemyState.Chase);
    }

    void Chase_Update()
    {
        var player = GameSystem.Instance.Player;
        Aim(player.transform.position - transform.position);
        Move(LookAt);
    }

    void Numb_Enter()
    {
        MoveSpeed = 0;
        numbTime = Time.time;
    }
    void Numb_Update()
    {
        if (Time.time - numbTime > NumbTime)
            StateMachine.ChangeState(EnemyState.Idle);
    }
}
