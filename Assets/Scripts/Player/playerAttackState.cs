using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    bool animationFinished;
    public override void Enter(PlayerStateMachine player)
    {
        player.changeAnim(PlayerStateMachine.states.Attack);
        Debug.Log("Entered Attack");
        animationFinished = false;
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Attack");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
        if (animationFinished == true) //left mouse
        {
            Debug.Log("change out of attack");
            player.ChangeState(PlayerStateMachine.states.Idle);
        }
    }

    public void finishedAnimation()
    {
        Debug.Log("transition success");
        animationFinished = true;
    }

}
