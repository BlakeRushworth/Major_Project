using UnityEngine;


[CreateAssetMenu(fileName = "Idle-Stand Still", menuName = "Player Logic/Idle Logic/Stand Still")]
public class PlayerIdleStandStill : PlayerIdleSOBase
{
    public override void DoAnimationTriggerEventLogic(Player.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
    }

    public override void DoPhyscisLogic()
    {
        base.DoPhyscisLogic();
    }

    public override void Initialize(GameObject gameObject, Player player)
    {
        base.Initialize(gameObject, player);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
