
public class EnemyState
{
    protected Enemy enemy;
    protected StateMachine statemachine;

    public EnemyState(Enemy enemy, StateMachine stateMachine)
    {
        this.enemy = enemy;
        this.statemachine = stateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FixedUpdate() { }
    public virtual void LogicUpdate() { }
    public virtual void AnimationEvent(Enemy.AnimationTriggerType triggerType){}
}
