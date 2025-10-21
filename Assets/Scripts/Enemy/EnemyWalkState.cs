using UnityEngine;

public class EnemyWalkState : EnemyBaseState
{
    private Vector2 movement;
    public override void Enter(EnemyStateMachine enemy)
    {
        enemy.changeAnim(EnemyStateMachine.states.Walk);
    }

    public override void Exit(EnemyStateMachine enemy)
    {
    }

    public override void finishedAnimation(EnemyStateMachine enemy)
    {

    }

    public override void PhysicsUpdate(EnemyStateMachine enemy)
    {
    }
}
