using System.Collections.Generic;
using System.Globalization;
using System.Runtime;
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

    public bool enemyTypesEnabled = true;
    public bool largeEnemyEnabled = true;
    public Color blue;
    public Color green;
    public Color red;
    public Color white;
    private int NUMBROFTYPES = 5;
    private int BIGENEMYCHANCE = 4;

    public float enemy_range = 3f;

    public GameObject poisonPuddle;
    public bool spawnPoison = false;

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

        if (largeEnemyEnabled)
        {
            int randomsize = Random.Range(0, BIGENEMYCHANCE);
            if (randomsize == 0)
            {
                transform.localScale *= 2f;
                enemy_range += 2f;
                attack_dist += 1f;
            }
        }
        if (enemyTypesEnabled)
        {
            int randomType = Random.Range(0, NUMBROFTYPES);
            if (randomType == 0)
            {
                //normal
            }
            else if (randomType == 1)
            {
                //poison
                SR.color = green;
            }
            else if (randomType == 2)
            {
                //burn
                SR.color = red;
            }
            else if (randomType == 3)
            {
                //freeze
                SR.color = blue;
            }
            else if (randomType == 4)
            {
                //speed
                SR.color = white;
                speed += 2f;
            }
            else
            {
                Debug.Log("enemyTypes unknown num");
            }
        }

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
        if (spawnPoison)
        {
            spawnPoison = false;
            Instantiate(poisonPuddle, transform.position, Quaternion.identity);
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
