using System;
using UnityEngine;

[RequireComponent(typeof(EnemyAttackRange), typeof(EnemyChaseRange))]
[RequireComponent(typeof(MovementComponent), typeof(WeaponComponent))]
// typeof(AnimationComponent), typeof(LayerComponent) in child
public class EnemyController : MonoBehaviour, IPoolable
{
    #region Components
    private MovementComponent Mov;
    private WeaponComponent Wep;
    private AnimationComponent Ani;
    private LayerComponent Lay;
    #endregion

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

    void Awake()
    {
        stateMachine = new StateMachine();
        enemyIdleState = new EnemyIdleState(this, stateMachine);
        enemyChaseState = new EnemyChaseState(this, stateMachine);
        enemyAttackState = new EnemyAttackState(this, stateMachine);
    }


    void Start()
    {
        Mov = GetComponent<MovementComponent>();
        Wep = GetComponent<WeaponComponent>();
        Ani = GetComponentInChildren<AnimationComponent>();
        Lay = GetComponentInChildren<LayerComponent>();
        stateMachine.Init(enemyIdleState);
    }

    void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdate();
        HandleInput();
    }

    public void OnSpawn()
    {
        
    }

    public void OnReturnToPool()
    {
        Mov.rb.linearVelocity = Vector2.zero;
        Mov.rb.angularVelocity = 0;
    }

    void HandleInput()
    {
        
    }

    private void AnimationTrigger(AnimationTriggerType animationTriggerType)
    { }

    public enum AnimationTriggerType
    {

    }

    #region SETTER
    public void SetAttackRange(bool b) => isInAttackRange = b;
    public void SetChaseRange(bool b) => isInChasingRange = b;
    #endregion
}