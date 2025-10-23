using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    Rigidbody2D player;
    public override void Enter(EnemyStateMachine enemy)
    {
        enemy.changeAnim(EnemyStateMachine.states.Attack);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public override void Exit(EnemyStateMachine enemy)
    {
    }

    public override void finishedAnimation(EnemyStateMachine enemy)
    {
        Debug.Log("transition success");
        enemy.ChangeState(EnemyStateMachine.states.Idle);
    }

    public override void attackcheck(EnemyStateMachine enemy)
    {
        Vector2 enemyPos = enemy.transform.position;
        Vector2 playerPos = player.transform.position;
        //Vector2 direction = (playerPos - enemyPos);
        float distance = Vector2.Distance(enemyPos, playerPos);

        if (distance <= 3)
        {
            //check player hit state
            Debug.Log("hit the player!");
            player.gameObject.GetComponent<PlayerStateMachine>().hitCooldown = true;
        }
    }

    public override void PhysicsUpdate(EnemyStateMachine enemy)
    {
        
    }
}
