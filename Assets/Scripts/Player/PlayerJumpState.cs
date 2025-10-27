using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerJumpState : PlayerBaseState
{
    private GameObject cross;
    private LineRenderer LR;

    private Vector2 movement;
    private const float ANIMATION_TIME = 1.1f;
    private float distance;
    private Vector2 initialCrossPos;
    public override void Enter(PlayerStateMachine player)
    {
        cross = player.transform.GetChild(1).gameObject;
        LR = cross.GetComponent<LineRenderer>();
        initialCrossPos = cross.transform.position;
        player.GetComponent<CapsuleCollider2D>().enabled = false;
        player.changeAnim(PlayerStateMachine.states.Jump);
        Debug.Log("Entered jump");


        movement = (cross.transform.position - player.transform.position).normalized;
        distance = Vector2.Distance(player.transform.position, initialCrossPos);
        Debug.Log("distance: " + distance + " time: " + ANIMATION_TIME + " =  speed: " + distance / ANIMATION_TIME);
        //player.transform.Translate(movement * distance / ANIMATION_TIME);

        //player.RB.MovePosition.Lerp(player.RB.position + movement * distance / ANIMATION_TIME * Time.deltaTime);
        cross.GetComponent<SpriteRenderer>().enabled = false;
        LR.enabled = false;
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exited jump");
    }

    public override void finishedAnimation(PlayerStateMachine player)
    {
        player.transform.position = initialCrossPos;
        player.GetComponent<CapsuleCollider2D>().enabled = true;
        player.ChangeState(PlayerStateMachine.states.Idle);
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, initialCrossPos, distance / ANIMATION_TIME * Time.deltaTime);
    }
}
