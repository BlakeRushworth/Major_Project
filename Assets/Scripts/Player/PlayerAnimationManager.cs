using JetBrains.Annotations;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public PlayerAttackState AttackState;
    //public float testNum = 0f;

    public void Attack_Anim()
    {
        print("transition noticed");
        if (AttackState != null)
        {
            print("transition exists and attempted");
            AttackState.finishedAnimation();
        }
        
    }
}
