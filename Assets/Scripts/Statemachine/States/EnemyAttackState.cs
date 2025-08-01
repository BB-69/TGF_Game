public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!enemy.isInAttackRange) statemachine.ChangeState(enemy.enemyIdleState);
    }
    public override void AnimationEvent(Enemy.AnimationTriggerType triggerType) { }
}