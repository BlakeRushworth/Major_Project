using UnityEngine;

public class PlayerMeleeAttackState : PlayerBaseState
{
    bool animationFinished;

    public override void Enter(PlayerStateMachine player)
    {
        player.changeAnim(PlayerStateMachine.states.MeleeAttack);
        Debug.Log("Entered Attack");
        animationFinished = false;
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Attack");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
    }

    public override void finishedAnimation(PlayerStateMachine player)
    {
        Debug.Log("transition success");
        animationFinished = true;
        player.ChangeState(PlayerStateMachine.states.Idle);
    }

}