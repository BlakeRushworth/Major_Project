using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void Enter(EnemyStateMachine enemy);
    public abstract void Exit(EnemyStateMachine enemy);
    public abstract void PhysicsUpdate(EnemyStateMachine enemy);
    public abstract void finishedAnimation(EnemyStateMachine enemy);

    public abstract void attackcheck(EnemyStateMachine enemy);
}