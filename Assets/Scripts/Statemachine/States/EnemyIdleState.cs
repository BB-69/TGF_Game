public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
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
        if (enemy.isInChasingRange) statemachine.ChangeState(enemy.enemyChaseState);
    }
    public override void AnimationEvent(Enemy.AnimationTriggerType triggerType) { }
}