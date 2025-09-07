using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        player.PlayerIdleBaseIntance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("hi from idle state");
        player.PlayerIdleBaseIntance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        player.PlayerIdleBaseIntance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        player.PlayerIdleBaseIntance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.PlayerIdleBaseIntance.DoPhyscisLogic();
    }
}
