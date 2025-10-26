using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerJumpState : PlayerBaseState
{
    public override void Enter(PlayerStateMachine player)
    {
        player.ChangeState(PlayerStateMachine.states.Jump);
        Debug.Log("Entered jump");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exited jump");
    }

    public override void finishedAnimation(PlayerStateMachine player)
    {
        //player.ChangeState(PlayerStateMachine.states.Idle);
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
        //player.RB.MovePosition(player.RB.position + movement * player.rollSpeed * Time.deltaTime);
        //player.transform.Translate(Vector3.forward * 2f);
    }
}
