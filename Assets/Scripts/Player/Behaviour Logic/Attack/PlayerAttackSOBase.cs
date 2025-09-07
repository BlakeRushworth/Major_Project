using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerAttackSOBase : ScriptableObject
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

    public virtual void DoFrameUpdateLogic() { }

    public virtual void DoPhysicsLogic() { }

    public virtual void DoAnimationTriggerEventLogic(Player.AnimationTriggerType triggerType) { }

    public virtual void ResetValues() { }
}
