using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyWalkState : EnemyBaseState
{
    Rigidbody2D player;
    public override void Enter(EnemyStateMachine enemy)
    {
        enemy.changeAnim(EnemyStateMachine.states.Walk);
        //Debug.Log("hi from enemy idle");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public override void Exit(EnemyStateMachine enemy)
    {
    }

    public override void finishedAnimation(EnemyStateMachine enemy)
    {

    }

    public override void attackcheck(EnemyStateMachine enemy)
    {

    }

    public override void PhysicsUpdate(EnemyStateMachine enemy)
    {
        Vector2 enemyPos = enemy.transform.position;
        Vector2 playerPos = player.transform.position;
        Vector2 direction = (playerPos - enemyPos);
        float distance = Vector2.Distance(enemyPos, playerPos);

        // Perform a Raycast between the enemy and the player
        Debug.DrawRay(enemyPos, direction, color: Color.white);
        RaycastHit2D hit = Physics2D.Raycast(enemyPos, direction, distance);
        if (distance <= enemy.attack_dist)
        {
            enemy.ChangeState(EnemyStateMachine.states.Attack);
            return;
        }
        if (hit.collider != null)
        {
            if (hit.collider is TilemapCollider2D)
            {
                Debug.DrawRay(enemyPos, direction, color: Color.red);
                //Debug.Log($" View is blocked by tilemap '{hit.collider.name}'.");
                enemy.ChangeState(EnemyStateMachine.states.Idle);
            }
            else
            {
                Debug.DrawRay(enemyPos, direction, color: Color.yellow);
                //Debug.Log($"Object '{hit.collider.name}' is blocking the view.");

                
            }
        }
        else
        {
            Debug.Log(" No hit detected (no collider in between).");
        }

        enemy.RB.MovePosition(enemy.RB.position + direction.normalized * enemy.speed * Time.deltaTime);

        if (direction.x > 0)
        {
            enemy.SR.flipX = true;
        }
        else if (direction.x < 0)
        {
            enemy.SR.flipX = false;
        }
    }
}
