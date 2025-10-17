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
        Debug.Log("UPDATING IDLE");

        if (movement != Vector2.zero)
        {
            player.ChangeState(PlayerStateMachine.states.Walk);
        }
        
        if (Input.GetKey(KeyCode.Mouse0) == true) //left mouse
        {
            Debug.Log("click");
            player.ChangeState(PlayerStateMachine.states.Attack);
        }

        if (Input.GetKey(KeyCode.Q) == true)
        {
            Debug.Log("go to roll");
            player.ChangeState(PlayerStateMachine.states.Roll);
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
}
