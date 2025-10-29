using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerStateMachine : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    public float speed;
    public float rollSpeed;
    public float hitCooldownDuration = 2f;

    public Tilemap targetTilemap;

    public bool hitCooldown = false;
    public string enemytypehitby;
    public bool attemptEnemyFreeze = false;
    private bool donehit = true;

    [HideInInspector]
    public Rigidbody2D RB;
    [HideInInspector]
    public SpriteRenderer SR;
    [HideInInspector]
    public Animator anim;

    public Dictionary<states, PlayerBaseState> statesDict;
    public PlayerBaseState currentState;

    public GameObject arrow;
    public GameObject enemy;

    public GameObject EnemyIce;

    public bool turnInvis  = false;

    public enum states
    {
        Idle, Walk, RangeAttack, MeleeAttack, Hit, Death, Roll, Jump
    }

    void Start()
    {


        MaxHealth = skill_tree.maxHealth;
        speed = skill_tree.player_speed;
        rollSpeed = skill_tree.player_roll_speed;
        CurrentHealth = MaxHealth;

        Debug.Log("speed = " + speed + " roll speed = " + rollSpeed + " jump range = ");
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        

        statesDict = new Dictionary<states, PlayerBaseState>
        {
            { states.Idle, new PlayerIdleState() },
            { states.Walk, new PlayerWalkState() },
            { states.RangeAttack, new PlayerRangeAttackState() },
            { states.MeleeAttack, new PlayerMeleeAttackState() },
            { states.Jump, new PlayerJumpState() },
            { states.Hit, new PlayerHitState() },
            { states.Death, new PlayerDeathState() },
            { states.Roll, new PlayerRollState() }
        };

        ChangeState(states.Idle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentHealth = health_bar_test.currentHealth;

        currentState?.PhysicsUpdate(this);
        //Debug.Log(CurrentHealth);


        if (CurrentHealth <= 0 && anim.GetBool("DeathLock") == false) 
        {
            anim.SetBool("DeathLock", true);
            ChangeState(states.Death);
        }

        Debug.Log("hitcooldown = " + hitCooldown + " donehit = " + donehit);
        if (hitCooldown && donehit)
        {
            if (enemytypehitby == "poison")
            {
                StartCoroutine(BeenHitBurn());
            }
            if (enemytypehitby == "burn")
            {
                StartCoroutine(BeenHitBurn());
            }
            else if (enemytypehitby == "freeze")
            {
                StartCoroutine(BeenHitFreeze());
            }
            else
            {
                StartCoroutine(BeenHit());
            }
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
        anim.SetBool("RangeAttack", stateName == states.RangeAttack);
        anim.SetBool("MeleeAttack", stateName == states.MeleeAttack);
        anim.SetBool("Walk", stateName == states.Walk);
        anim.SetBool("Roll", stateName == states.Roll);
        anim.SetBool("Death", stateName == states.Death);
        anim.SetBool("Hit", stateName == states.Hit);
        anim.SetBool("Jump", stateName == states.Jump);
    }


    public IEnumerator BeenHit()
    {
        donehit = false;
        Debug.Log("burn hit!");
        health_bar_test.currentHealth -= 10f;
        SR.color = Color.red;
        hitCooldown = false;
        yield return new WaitForSeconds(hitCooldownDuration); // Wait for 2 seconds
        donehit = true;
        SR.color = Color.white;
        Debug.Log("hit Countdown finished!");
    }

    public IEnumerator BeenHitFreeze()
    {
        donehit = false;
        Debug.Log("freeze hit!");
        if (!skill_tree.FreezingImmunity)
        {
            attemptEnemyFreeze = true;
        }
        health_bar_test.currentHealth -= 10f;
        SR.color = Color.red;
        hitCooldown = false;
        yield return new WaitForSeconds(hitCooldownDuration); // Wait for 2 seconds
        attemptEnemyFreeze = false;
        donehit = true;
        SR.color = Color.white;
        Debug.Log("hit Countdown finished!");
    }

    public IEnumerator BeenHitBurn()
    {
        donehit = false;
        Debug.Log("normal hit!");
        health_bar_test.currentHealth -= 10f;
        SR.color = Color.red;
        hitCooldown = false;
        yield return new WaitForSeconds(hitCooldownDuration); // Wait for 2 seconds
        if (!skill_tree.FreezingImmunity)
        {
            health_bar_test.currentHealth -= 10f;
        }
        donehit = true;
        SR.color = Color.white;
        Debug.Log("hit Countdown finished!");
    }

    public IEnumerator BeenHitPosion()
    {
        if (!skill_tree.PoisonedImmunity)
        {
            donehit = false;
            Debug.Log("burn hit!");
            health_bar_test.currentHealth -= 5f;
            SR.color = Color.red;
            hitCooldown = false;
            yield return new WaitForSeconds(hitCooldownDuration); // Wait for 2 seconds
            donehit = true;
            SR.color = Color.white;
            Debug.Log("hit Countdown finished!");
        }
    }
}
