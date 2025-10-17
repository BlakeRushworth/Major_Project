using UnityEngine;

public class PlayerHitState : PlayerBaseState
{
    public override void Enter(PlayerStateMachine player)
    {
        player.changeAnim(PlayerStateMachine.states.Hit);
        Debug.Log("Entered Hit");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Hit");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {

    }

    public override void finishedAnimation(PlayerStateMachine player)
    {
        player.ChangeState(PlayerStateMachine.states.Idle);
    }
}
