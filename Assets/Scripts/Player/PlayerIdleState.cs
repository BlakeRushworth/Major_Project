using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void Enter(PlayerStateMachine player)
    {
        player.changeAnim(PlayerStateMachine.states.Idle);
        Debug.Log("Entered Idle");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Idle");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f)
        {
            player.ChangeState(PlayerStateMachine.states.Walk);
        }
    }
}
