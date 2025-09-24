using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float CurrentHealth;
    public float speed = 10f;

    [HideInInspector]
    public Rigidbody2D RB;
    [HideInInspector]
    public SpriteRenderer SR;
    [HideInInspector]
    public Animator anim;

    public Dictionary<states, PlayerBaseState> statesDict;
    public PlayerBaseState currentState;

    public enum states
    {
        Idle, Walk, Attack, Hit, Death, Roll
    }

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        CurrentHealth = MaxHealth;

        statesDict = new Dictionary<states, PlayerBaseState>
        {
            { states.Idle, new PlayerIdleState() },
            { states.Walk, new PlayerWalkState() },
            { states.Attack, new PlayerAttackState() },
            { states.Roll, new PlayerRollState() },
            { states.Hit, new PlayerHitState() },
            { states.Death, new PlayerDeathState() }
        };

        ChangeState(states.Idle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       currentState?.PhysicsUpdate(this);
    }

    public void ChangeState(states stateName)
    {
        currentState?.Exit(this);
        currentState = statesDict[stateName];
        currentState?.Enter(this);
    }



    public void changeAnim(states stateName) 
    {
        if (stateName == states.Idle)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", false);
        }
        else if (stateName == states.Walk)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", true);
        }
        else if (stateName == states.Attack)
        {
            anim.SetBool("Attack", true);
            anim.SetBool("Walk", false);
        }

        /*OR You can do it this way apparently, bit of fun
        anim.SetBool("Attack", stateName == states.Attack);
        anim.SetBool("Walk", stateName == states.Walk);*/

    }

}
