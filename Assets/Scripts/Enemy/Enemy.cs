using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public enum EnemyState
{
    Idle,
    Chase,
    Numb,
    Wander,
    AttackTower,
    Dead,
}
public class Enemy : Entity {
    public float Damage = 40;
    public bool Rest = true;
    public bool Lighted = false;
    public Material RestMaterial;
    public Material ActiveMateiral;
    public GameObject DeadbodyPrefab;
    public GameObject DeadEffect;
    public StateMachine<EnemyState> StateMachine;
    public float NumbTime = 1;
    public float Acceleration = 1;
    public float MaxSpeed = 5;
    public float MaxRotateSpeed = 600;
    public float MinRotateSpeed = 160;
    public float DetectRadiusMultiple = 2;
    float numbTime = 0;
    protected float currentTargetSpeed = 0;
    protected float currentDetcetRadiusMultiple = 1;

    protected virtual void Awake()
    {
        StateMachine = StateMachine<EnemyState>.Initialize(this, EnemyState.Wander);
        MoveSpeed = 0;
    }
    // Use this for initialization
    void Start () {
	}

    public override void Move(Vector2 dir)
    {
        if(dir.magnitude>0)
        {
            MoveSpeed = Mathf.Clamp(MoveSpeed + Acceleration * Time.deltaTime, 0, currentTargetSpeed);
        }
        else
        {
            MoveSpeed = 0;
        }
        base.Move(dir);
    }
    // Update is called once per frame
    public void Update()
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
    public void ApplyDamage(float damage)
    {
        this.HP -= damage;
        this.HP = Mathf.Clamp(this.HP, 0, MaxHP);
        if (HP <= 0)
        {
            StateMachine.ChangeState(EnemyState.Dead);
        }
    }
    public virtual bool Detect()
    {
        var player = GameManager.Instance.Player.GetComponent<PlayerProperty>();
        var dist = (player.transform.position - transform.position).magnitude;
        if (dist > player.DetectRadius*currentDetcetRadiusMultiple)
            return false;
        var hits = Physics2D.RaycastAll(transform.position, player.transform.position - transform.position, dist, 1 << 8);
        if (hits.Length <= 0)
            return true;
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && StateMachine.State == EnemyState.Chase)
            StateMachine.ChangeState(EnemyState.Numb);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            var bullet = collision.GetComponentInParent<BulletProperty>();
            if (bullet == null) return;
            ApplyDamage(bullet.Damage);
            bullet.gameObject.SetActive(false);
            Destroy(bullet.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && StateMachine.State == EnemyState.Chase)
            StateMachine.ChangeState(EnemyState.Numb);
    }



    protected virtual void Idle_Update()
    {
        Rest = true;
        if (Detect())
            StateMachine.ChangeState(EnemyState.Chase);
    }

    protected void Chase_Enter()
    {
        Rest = false;
        currentDetcetRadiusMultiple = DetectRadiusMultiple;
    }

    protected void Chase_Update()
    {
        var player = GameManager.Instance.Player;
        currentTargetSpeed = MaxSpeed;
        Aim(player.transform.position - transform.position);
        Move(LookAt);
        
    }

    protected void Numb_Enter()
    {
        MoveSpeed = 0;
        numbTime = Time.time;
    }
    protected void Numb_Update()
    {
        if (Time.time - numbTime > NumbTime)
            StateMachine.ChangeState(EnemyState.Idle);
    }
    IEnumerator Wander_Coroutine()
    {
        while(true)
        {
            var nextChangeTime = Time.time + Random.value * 5 + 1;
            var dir = Random.insideUnitCircle;
            var speed = Random.Range(0, 0.5f);
            if (speed < 0.2)
                speed = 0;
            while(Time.time<nextChangeTime)
            {
                currentTargetSpeed = speed;
                Move(dir);
                Aim(dir);
                yield return null;
            }
        }
    }
    IEnumerator wander;
    public virtual void Wander_Enter()
    {
        wander = Wander_Coroutine();
    }
    public virtual void Wander_Update()
    {
        if (Detect())
            StateMachine.ChangeState(EnemyState.Chase);
        wander.MoveNext();
    }

    public virtual void Dead_Enter()
    {
        if (DeadEffect)
            Instantiate(DeadEffect, transform.position, Quaternion.identity);
        if (DeadbodyPrefab)
            Instantiate(DeadbodyPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
