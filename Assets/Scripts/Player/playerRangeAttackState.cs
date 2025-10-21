using Unity.Mathematics;
using UnityEngine;

public class PlayerRangeAttackState : PlayerBaseState
{
    public bool shootArrow = false;

    public override void Enter(PlayerStateMachine player)
    {
        player.changeAnim(PlayerStateMachine.states.RangeAttack);
        Debug.Log("Entered Attack");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Attack");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
        /*
        Debug.Log("arrow");
        if (shootArrow == true) 
        {
            Debug.Log("shot arrow");
            Object.Instantiate(arrow, player.RB.position, quaternion.identity);
        }
        shootArrow = false;
        */
    }

    public override void finishedAnimation(PlayerStateMachine player)
    {
        Debug.Log("transition success");
        Object.Instantiate(player.arrow, player.RB.position, quaternion.identity);
        player.ChangeState(PlayerStateMachine.states.Idle);
    }
}
