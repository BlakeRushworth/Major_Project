using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    

    public PlayerAttackState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        player.PlayerAttackBaseIntance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("hi from Attack state");
        player.PlayerAttackBaseIntance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        player.PlayerAttackBaseIntance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        player.PlayerAttackBaseIntance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.PlayerAttackBaseIntance.DoPhysicsLogic();
    }
}
