using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    private Vector2 movement;
    public override void Enter(EnemyStateMachine enemy)
    {
        enemy.changeAnim(EnemyStateMachine.states.Death);
    }

    public override void Exit(EnemyStateMachine enemy)
    {
    }

    public override void finishedAnimation(EnemyStateMachine enemy)
    {

    }

    public override void attackcheck(EnemyStateMachine enemy)
    {

    }

    public override void PhysicsUpdate(EnemyStateMachine enemy)
    {
    }
}
