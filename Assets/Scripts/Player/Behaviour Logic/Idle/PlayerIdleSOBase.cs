using UnityEngine;

public class PlayerIdleSOBase : ScriptableObject
{
    protected Player player;
    protected Transform transform;
    protected GameObject gameObject;

    public virtual void Initialize(GameObject gameObject, Player player)
    {
        this.gameObject = gameObject;
        this.transform = gameObject.transform;
        this.player = player;
    }

    public virtual void DoEnterLogic() { }

    public virtual void DoExitLogic() { ResetValues(); }

    public virtual void DoFrameUpdateLogic() 
    {
        if (player.IsMoving)
        {
            player.StateMachine.ChangeState(player.WalkState);
        }
        if (player.IsAttacking)
        {
            player.StateMachine.ChangeState(player.AttackState);
        }
    }

    public virtual void DoPhyscisLogic() { }

    public virtual void DoAnimationTriggerEventLogic(Player.AnimationTriggerType triggerType) {    }

    public virtual void ResetValues() { }
}
