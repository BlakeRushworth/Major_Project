using UnityEngine;

public class PlayerRollState : PlayerBaseState
{

    private Vector2 movement;
    public override void Enter(PlayerStateMachine player)
    {
        player.changeAnim(PlayerStateMachine.states.Roll);
        Debug.Log("Entered Roll");

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Debug.Log(stanima_bar.currentStanima);
        if (movement == Vector2.zero)
        {
            player.ChangeState(PlayerStateMachine.states.Idle);
        }
        else
        {
            stanima_bar.currentStanima -= stanima_bar.stanima_cost;
            Debug.Log("rolled cost done");
            Debug.Log(stanima_bar.currentStanima);
        }
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Roll");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
        player.RB.MovePosition(player.RB.position + movement * player.rollSpeed * Time.deltaTime);
    }

    public override void finishedAnimation(PlayerStateMachine player)
    {
        Debug.Log("roll to idle");
        player.ChangeState(PlayerStateMachine.states.Idle);
    }
}
