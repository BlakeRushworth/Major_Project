using JetBrains.Annotations;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    PlayerStateMachine player;
    PlayerRangeAttackState attack;

    private void Start()
    {
        player = GetComponent<PlayerStateMachine>();
    }

    public PlayerRangeAttackState RangeAttackState;
    //public float testNum = 0f;

    public void Anim_End()
    {
        print("transition noticed");
        print("transition exists and attempted");
        player.currentState.finishedAnimation(player);
    }

    public void shoot_arrow()
    {
        print("shot arrow");
        attack.shootArrow = true;
    }
}
