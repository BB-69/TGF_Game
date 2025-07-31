using System;
using UnityEngine;
[RequireComponent(typeof(EnemyAttackRange), typeof(EnemyChaseRange), typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour, IDamagable, IPoolable
{
    #region Stats
    public float currentHP { get; private set; }
    [SerializeField] protected CharData charData;
    protected EnemyStats enemyStats;

    #endregion
    Rigidbody2D Rb;
    #region StateMachine

    protected StateMachine stateMachine;
    public EnemyIdleState enemyIdleState{ get; private set; }
    public EnemyChaseState enemyChaseState{ get; private set; }
    public EnemyAttackState enemyAttackState{ get; private set; }
    #endregion

    #region TriggerCheck
    public bool isInChasingRange { get; private set; }
    public bool isInAttackRange { get; private set; }
    #endregion

    protected void Awake()
    {
        stateMachine = new StateMachine();
        enemyIdleState = new EnemyIdleState(this, stateMachine);
        enemyChaseState = new EnemyChaseState(this, stateMachine);
        enemyAttackState = new EnemyAttackState(this, stateMachine);

        enemyStats = new EnemyStats(charData.maxHP, charData.ATK, charData.SPD, charData.DEF);
    }


    protected void Start()
    {
        currentHP = enemyStats.maxHP;
        Rb = GetComponent<Rigidbody2D>();
        stateMachine.Init(enemyIdleState);
    }
    protected void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    protected void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdate();
    }

    public void Move(Vector2 vel)
    {
        Rb.linearVelocity = vel;
    }
    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0) Die();
    }

    protected void Die()
    {
        PoolManager.Instance.Despawn(gameObject);
    }

    private void AnimationTrigger(AnimationTriggerType animationTriggerType)
    { }

    public void OnReturnToPool()
    {
        throw new NotImplementedException();
    }

    public void OnSpawn()
    {
        throw new NotImplementedException();
    }

    public enum AnimationTriggerType
    {

    }

    #region SETTER
    public void SetAttackRange(bool b) => isInAttackRange = b;
    public void SetChaseRange(bool b) => isInChasingRange = b;
    #endregion
}