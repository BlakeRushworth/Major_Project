using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public float MaxHealth = 20f;
    public float CurrentHealth;
    public float speed = 10f;
    public float detect_dist = 10f;
    public float attack_dist = 2f;

    [HideInInspector]
    public Rigidbody2D RB;
    [HideInInspector]
    public SpriteRenderer SR;
    [HideInInspector]
    public Animator anim;

    public Dictionary<states, EnemyBaseState> statesDict;
    public EnemyBaseState currentState;

    public enum states
    {
        Idle, Walk, Attack, Hit, Death, Spawn
    }

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        CurrentHealth = MaxHealth;

        statesDict = new Dictionary<states, EnemyBaseState>
        {
            { states.Spawn, new EnemySpawnState() },
            { states.Idle, new EnemyIdleState() },
            { states.Walk, new EnemyWalkState() },
            { states.Attack, new EnemyAttackState() },
            { states.Hit, new EnemyHitState() },
            { states.Death, new EnemyDeathState() }
        };

        ChangeState(states.Spawn);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState?.PhysicsUpdate(this);
        //Debug.Log(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            ChangeState(EnemyStateMachine.states.Death);
        }
    }

    public void ChangeState(states stateName)
    {
        currentState?.Exit(this);
        currentState = statesDict[stateName];
        currentState?.Enter(this);
    }



    public void changeAnim(states stateName)
    {
        anim.SetBool("Spawn", stateName == states.Spawn);
        anim.SetBool("Attack", stateName == states.Attack);
        anim.SetBool("Walk", stateName == states.Walk);
        anim.SetBool("Death", stateName == states.Death);
        anim.SetBool("Hit", stateName == states.Hit);
    }
}
