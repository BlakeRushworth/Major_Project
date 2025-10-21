using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void Enter(PlayerStateMachine player);
    public abstract void Exit(PlayerStateMachine player);
    public abstract void PhysicsUpdate(PlayerStateMachine player);
    public abstract void finishedAnimation(PlayerStateMachine player);
}
