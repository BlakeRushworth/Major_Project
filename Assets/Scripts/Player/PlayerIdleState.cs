using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerIdleState : PlayerBaseState
{
    private Vector2 movement;
    private GameObject cross;
    private LineRenderer LR;
    public override void Enter(PlayerStateMachine player)
    {

        cross = player.transform.GetChild(1).gameObject;
        LR = cross.GetComponent<LineRenderer>();
        player.changeAnim(PlayerStateMachine.states.Idle);
        Debug.Log("Entered Idle");
    }

    public override void Exit(PlayerStateMachine player)
    {
        Debug.Log("Exit Idle");
    }

    public override void finishedAnimation(PlayerStateMachine player)
    {
        
    }

    public override void PhysicsUpdate(PlayerStateMachine player)
    {
        if (Input.GetKey(KeyCode.Space) == true)
        {
            LR.SetPosition(0, player.transform.position);
            LR.SetPosition(1, cross.transform.position);
            Debug.DrawLine(player.transform.position, cross.transform.position);
            cross.GetComponent<SpriteRenderer>().enabled = true;
            LR.enabled = true;
            Debug.Log("space pressed in idle");
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = cross.transform.position.z;
            cross.transform.position = mouseWorldPosition;

            if (Input.GetKey(KeyCode.Mouse0) == true) //left mouse
            {
                Vector3Int cellPosition = player.targetTilemap.WorldToCell(mouseWorldPosition);
                TileBase tileAtPosition = player.targetTilemap.GetTile(cellPosition);
                if (tileAtPosition == null)
                {
                    cross.GetComponent<SpriteRenderer>().enabled = false;
                    LR.enabled = false;
                    Debug.Log("did NOT hit tilemap on idle click");
                    player.ChangeState(PlayerStateMachine.states.Jump);
                    
                }
                else
                {
                    Debug.Log("hit tilemap on idle click");
                }
            }
            return;
        }
        else
        {
            cross.GetComponent<SpriteRenderer>().enabled = false;
            LR.enabled = false;
        }
        if (Input.GetKey(KeyCode.Mouse0) == true) //left mouse
        {
            Debug.Log("left click");
            player.ChangeState(PlayerStateMachine.states.RangeAttack);
            //return;
        }
        
        else if (Input.GetKey(KeyCode.Mouse1) == true) //right mouse
        {
            Debug.Log("right click");
            player.ChangeState(PlayerStateMachine.states.MeleeAttack);
            //return;
        }

        else if (Input.GetKey(KeyCode.Q) == true && stanima_bar.currentStanima > stanima_bar.stanima_cost)
        {
            Debug.Log("idle to roll");
            player.ChangeState(PlayerStateMachine.states.Roll);
            //return;
        }

        else if (movement != Vector2.zero)
        {
            player.ChangeState(PlayerStateMachine.states.Walk);
            //return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
}
