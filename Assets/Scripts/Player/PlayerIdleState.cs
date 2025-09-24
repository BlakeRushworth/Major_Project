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

    public override void PhysicsUpdate(PlayerStateMachine player)
    {

        if (movement != Vector2.zero)
        {
            player.ChangeState(PlayerStateMachine.states.Walk);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) == true) //left mouse
        {
            player.ChangeState(PlayerStateMachine.states.Attack);
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
}
