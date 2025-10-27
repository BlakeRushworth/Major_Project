using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerStateMachine : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float CurrentHealth;
    public float speed = 10f;
    public float rollSpeed = 20f;
    public float hitCooldownDuration = 2f;

    public Tilemap targetTilemap;

    public bool hitCooldown = false;

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

    public enum states
    {
        Idle, Walk, RangeAttack, MeleeAttack, Hit, Death, Roll, Jump
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
        health_bar_test.currentHealth = CurrentHealth;
        health_bar_test.maxHealth = MaxHealth;
        currentState?.PhysicsUpdate(this);
        //Debug.Log(CurrentHealth);


        if (CurrentHealth <= 0 && anim.GetBool("DeathLock") == false) 
        {
            anim.SetBool("DeathLock", true);
            ChangeState(states.Death);
        }
        
        if (hitCooldown)
        {
            StartCoroutine(BeenHit());
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

    IEnumerator BeenHit()
    {
        Debug.Log("can hit! woo");
        CurrentHealth -= 10f;
        SR.color = Color.red;
        hitCooldown = false;
        yield return new WaitForSeconds(hitCooldownDuration); // Wait for 2 seconds
        hitCooldown = false;
        SR.color = Color.white;
        Debug.Log("hit Countdown finished!");
    }
}
