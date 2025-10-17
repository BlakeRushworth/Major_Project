using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    private Vector2 movement;

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
        

        if (movement == Vector2.zero)
        {
            player.ChangeState(PlayerStateMachine.states.Idle);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) == true) //left mouse
        {
            player.ChangeState(PlayerStateMachine.states.Attack);
        }

        if (Input.GetKey(KeyCode.Q) == true)
        {
            player.ChangeState(PlayerStateMachine.states.Roll);
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        player.RB.MovePosition(player.RB.position + movement * player.speed * Time.deltaTime);
        //Debug.Log(movement);

        if (movement.x < 0)
        {
            player.SR.flipX = true;
        }
        else if (movement.x > 0)
        {
            player.SR.flipX = false;
        }

    }

    public override void finishedAnimation(PlayerStateMachine player)
    {

    }
}
