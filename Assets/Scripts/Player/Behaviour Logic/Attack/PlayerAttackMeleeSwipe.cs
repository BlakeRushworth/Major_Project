using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Melee Swipr", menuName = "Player Logic/Attack Logic/Melee Swipe")]
public class PlayerAttackMeleeSwipe : PlayerAttackSOBase
{
    private float _exitTimer;
    [SerializeField] private float _timeTillExit = 2f;

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

        player.MovePlayer(Vector2.zero);
        _exitTimer += Time.deltaTime;

        if (_exitTimer > _timeTillExit)
        {
            player.StateMachine.ChangeState(player.IdleState);
        }
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, Player player)
    {
        base.Initialize(gameObject, player);
    }

    public override void ResetValues()
    {
        base.ResetValues();

        _exitTimer = 0;
    }
}
