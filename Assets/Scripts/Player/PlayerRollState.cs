using UnityEngine;

public class PlayerRollState : PlayerBaseState
{
    public override void Enter(PlayerStateMachine player)
    {
        player.changeAnim(PlayerStateMachine.states.Roll);
        Debug.Log("Entered Roll");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Roll");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {

    }
}
