
public class EnemyState
{
    protected EnemyController enemy;
    protected StateMachine statemachine;

    public EnemyState(EnemyController enemy, StateMachine stateMachine)
    {
        this.enemy = enemy;
        this.statemachine = stateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FixedUpdate() { }
    public virtual void LogicUpdate() { }
    public virtual void AnimationEvent(EnemyController.AnimationTriggerType triggerType){}
}
