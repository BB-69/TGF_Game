

public class StateMachine
{
    public EnemyState currentState { get; private set; }
    public void Init(EnemyState startState)
    {
        currentState = startState;
        currentState.EnterState();
    }

    public void ChangeState(EnemyState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
