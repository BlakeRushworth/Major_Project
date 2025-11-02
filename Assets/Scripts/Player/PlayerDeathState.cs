using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public override void Enter(PlayerStateMachine player)
    {
        player.anim.SetTrigger("Death1");
        Debug.Log("Entered Death");
        player.audioManager.PlaySFX(player.audioManager.playerDeath, 1f);
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Death");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
        player.RB.bodyType = RigidbodyType2D.Static;
    }

    public override void finishedAnimation(PlayerStateMachine player)
    {

    }
}
