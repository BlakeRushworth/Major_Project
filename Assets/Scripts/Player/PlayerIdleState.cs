using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerBaseState
{
    private Vector2 movement;
    public override void Enter(PlayerStateMachine player)
    {
        player.changeAnim(PlayerStateMachine.states.Idle);
        Debug.Log("Entered Idle");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Idle");
    }

    public override void finishedAnimation(PlayerStateMachine player)
    {
        
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
        //Debug.Log("UPDATING IDLE");
        
        if (Input.GetKey(KeyCode.Mouse0) == true) //left mouse
        {
            Debug.Log("left click");
            player.ChangeState(PlayerStateMachine.states.RangeAttack);
            //return;
        }

        else if (Input.GetKey(KeyCode.Mouse1) == true) //right mouse
        {
            Debug.Log("right click");
            player.ChangeState(PlayerStateMachine.states.MeleeAttack);
            //return;
        }

        else if (Input.GetKey(KeyCode.Q) == true)
        {
            Debug.Log("idle to roll");
            player.ChangeState(PlayerStateMachine.states.Roll);
            //return;
        }

        else if (movement != Vector2.zero)
        {
            player.ChangeState(PlayerStateMachine.states.Walk);
            //return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
}
