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
        


        if (Input.GetKeyDown(KeyCode.Mouse0) == true) //left mouse
        {
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
            Debug.Log("walk to roll");
            player.ChangeState(PlayerStateMachine.states.Roll);
            //return;
        }

        else if (movement == Vector2.zero)
        {
            player.ChangeState(PlayerStateMachine.states.Idle);
            //return;
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
