using UnityEngine;

[CreateAssetMenu(fileName = "Walk-Normal Movement", menuName = "Player Logic/Walk Logic/Normal Movement")]
public class PlayerWalkNormalMovement : PlayerWalkSOBase
{
    [SerializeField] private int moveSpeed = 50;
    private Vector2 movement;

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

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        player.MovePlayer(movement * moveSpeed);
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
