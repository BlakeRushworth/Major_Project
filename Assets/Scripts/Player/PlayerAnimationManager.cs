using JetBrains.Annotations;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    PlayerStateMachine player;

    private void Start()
    {
        player = GetComponent<PlayerStateMachine>();
    }

    public PlayerAttackState AttackState;
    //public float testNum = 0f;

    public void Anim_End()
    {
        print("transition noticed");
        player.currentState.finishedAnimation(player);
        print("transition exists and attempted");
    }
}
