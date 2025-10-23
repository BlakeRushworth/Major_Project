using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    EnemyStateMachine enemy;
    PlayerStateMachine player;

    private void Start()
    {
        enemy = GetComponent<EnemyStateMachine>();
        player = GetComponent<PlayerStateMachine>();
    }

    public void Anim_End()
    {
        print("transition noticed");
        print("transition exists and attempted");
        enemy.currentState.finishedAnimation(enemy);
    }

    public void AttackAttempt()
    {
        Debug.Log("attack noticed");
        enemy.currentState.attackcheck(enemy);
    }
}
