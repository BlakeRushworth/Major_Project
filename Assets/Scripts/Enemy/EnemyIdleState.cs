using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyIdleState : EnemyBaseState
{
    Rigidbody2D player;
    public override void Enter(EnemyStateMachine enemy)
    {
        enemy.changeAnim(EnemyStateMachine.states.Idle);
        //Debug.Log("hi from enemy idle");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public override void Exit(EnemyStateMachine enemy)
    {

    }

    public override void finishedAnimation(EnemyStateMachine enemy)
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

        if (distance <= enemy.detect_dist)
        {

            if (hit.collider != null)
            {
                /*
                // Check what the ray hit
                if (hit.collider.gameObject == player.gameObject)
                {
                    Debug.DrawRay(enemyPos, direction, color: Color.green);
                    Debug.Log("Player is visible — no obstacles in between.");
                }
                */
                if (hit.collider is not TilemapCollider2D)
                {
                    Debug.DrawRay(enemyPos, direction, color: Color.yellow);
                    Debug.Log($"Object '{hit.collider.name}' is blocking the view.");

                    enemy.ChangeState(EnemyStateMachine.states.Walk);
                }
                else
                {
                    Debug.DrawRay(enemyPos, direction, color: Color.red);
                    Debug.Log($" View is blocked by tilemap '{hit.collider.name}'.");
                }
            }
            else
            {
                Debug.Log(" No hit detected (no collider in between).");
            }
        }
    }
}
