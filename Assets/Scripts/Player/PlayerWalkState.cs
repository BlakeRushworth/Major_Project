using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void Enter(PlayerStateMachine player)
    {
        player.changeAnim(PlayerStateMachine.states.Walk);
        Debug.Log("Entered Walk");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Walk");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(move) < 0.1f)
        {
            player.ChangeState(PlayerStateMachine.states.Idle);
        }
        
        player.RB.linearVelocity = new Vector2(move * player.speed, 0);
        Debug.Log(move);
        if (move < 0)
        {
            player.SR.flipX = true;
        }
        else
        {
            player.SR.flipX = false;
        }

    }
}
