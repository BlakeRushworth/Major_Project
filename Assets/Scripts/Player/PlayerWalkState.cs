using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerWalkState : PlayerBaseState
{
    private Vector2 movement;
    private GameObject cross;
    private LineRenderer LR;

    public override void Enter(PlayerStateMachine player)
    {
        cross = player.transform.GetChild(1).gameObject;
        LR = cross.GetComponent<LineRenderer>();
        player.changeAnim(PlayerStateMachine.states.Walk);
        Debug.Log("Entered Walk");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Walk");
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {

        if (Input.GetKey(KeyCode.Space) == true && stamina_bar.currentStanima >= stamina_bar.Jump_stanima_cost)
        {
            player.ChangeState(PlayerStateMachine.states.Idle);
            //    LR.SetPosition(0, player.transform.position);
            //    LR.SetPosition(1, cross.transform.position);
            //    //Debug.DrawLine(player.transform.position, cross.transform.position);
            //    cross.GetComponent<SpriteRenderer>().enabled = true;
            //    LR.enabled = true;
            //    Debug.Log("space pressed in walk");
            //    Vector3 mouseScreenPosition = Input.mousePosition;
            //    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            //    mouseWorldPosition.z = cross.transform.position.z;
            //    cross.transform.position = mouseWorldPosition;

            //    if (Input.GetKey(KeyCode.Mouse0) == true) //left mouse
            //    {
            //        Vector3Int cellPosition = player.targetTilemap.WorldToCell(mouseWorldPosition);
            //        TileBase tileAtPosition = player.targetTilemap.GetTile(cellPosition);
            //        if (tileAtPosition == null)
            //        {
            //            stamina_bar.currentStanima -= stamina_bar.Jump_stanima_cost;
            //            cross.GetComponent<SpriteRenderer>().enabled = false;
            //            LR.enabled = false;
            //            Debug.Log("did NOT hit tilemap on idle click");
            //            player.ChangeState(PlayerStateMachine.states.Jump);

            //        }
            //        else
            //        {
            //            Debug.Log("hit tilemap on idle click");
            //        }
            //    }
            //    return;
            //}
            //else
            //{
            //    cross.GetComponent<SpriteRenderer>().enabled = false;
            //    LR.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) == true) //left mouse
        {
            player.ChangeState(PlayerStateMachine.states.RangeAttack);
            //return;
        }

        else if (Input.GetKey(KeyCode.Mouse1) == true) //right mouse
        {
            Debug.Log("right click");
            player.ChangeState(PlayerStateMachine.states.MeleeAttack);
            //return;
        }

        else if (Input.GetKey(KeyCode.Q) == true && stamina_bar.currentStanima > stamina_bar.Roll_stanima_cost)
        {
            Debug.Log("walk to roll");
            player.ChangeState(PlayerStateMachine.states.Roll);
            //return;
        }

        else if (movement == Vector2.zero)
        {
            player.ChangeState(PlayerStateMachine.states.Idle);
            //return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        player.RB.MovePosition(player.RB.position + movement * player.speed * Time.deltaTime);
        //Debug.Log(movement);

        if (movement.x < 0)
        {
            player.SR.flipX = true;
        }
        else if (movement.x > 0)
        {
            player.SR.flipX = false;
        }

    }

    public override void finishedAnimation(PlayerStateMachine player)
    {

    }
}
