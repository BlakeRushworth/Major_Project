using UnityEngine;

public class EnemySpawnState : EnemyBaseState
{
    public override void attackcheck(EnemyStateMachine enemy)
    {
        
    }

    public override void Enter(EnemyStateMachine enemy)
    {
        Debug.Log("Entered spawn state");
        enemy.changeAnim(EnemyStateMachine.states.Attack);
    }

    public override void Exit(EnemyStateMachine enemy)
    {
        Debug.Log("Exited spawn state");
    }

    public override void finishedAnimation(EnemyStateMachine enemy)
    {
        enemy.ChangeState(EnemyStateMachine.states.Idle);
    }

    public override void PhysicsUpdate(EnemyStateMachine enemy)
    {
        
    }
}
