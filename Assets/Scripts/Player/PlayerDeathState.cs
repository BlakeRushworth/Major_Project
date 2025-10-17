using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public override void Enter(PlayerStateMachine player)
    {
        player.changeAnim(PlayerStateMachine.states.Death);
        Debug.Log("Entered Death");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Death");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
    }

    public override void finishedAnimation(PlayerStateMachine player)
    {

    }
}
