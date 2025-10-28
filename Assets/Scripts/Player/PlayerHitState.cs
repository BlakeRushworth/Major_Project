using UnityEngine;

public class PlayerHitState : PlayerBaseState
{
    public override void Enter(PlayerStateMachine player)
    {
        player.EnemyIce.GetComponent<SpriteRenderer>().enabled = true;
        player.changeAnim(PlayerStateMachine.states.Hit);
        player.GetComponent<CapsuleCollider2D>().enabled = false;
        Debug.Log("Entered Hit");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Hit");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {

    }

    public override void finishedAnimation(PlayerStateMachine player)
    {
        player.EnemyIce.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<CapsuleCollider2D>().enabled = true;
        player.ChangeState(PlayerStateMachine.states.Idle);
    }
}
