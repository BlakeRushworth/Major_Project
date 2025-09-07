using UnityEngine;

public class PlayerWalkState : PlayerState
{
    

    public PlayerWalkState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        player.PlayerWalkBaseIntance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("hi from walk state");

        player.PlayerWalkBaseIntance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        player.PlayerWalkBaseIntance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        player.PlayerWalkBaseIntance.DoFrameUpdateLogic();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.PlayerWalkBaseIntance.DoPhyscisLogic();
    }
}
