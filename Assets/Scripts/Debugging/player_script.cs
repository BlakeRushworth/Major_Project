using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class player_script : MonoBehaviour
{

    private Vector2 movement;

    [HideInInspector]
    public Rigidbody2D RB;
    //[HideInInspector]
    //public SpriteRenderer SR;
    [HideInInspector]
    public Animator anim;
    
    public float maxHealth = 100f;
    public float currentHealth;
    public float movementSpeed = 10f;
    public float rollSpeed = 20f;

    private bool canMove = true;

    public enum states
    {
        Idle, Walk, RangeAttack, MeleeAttack, Hit, Death, Roll
    }
    

    void Start()
    {
        currentHealth = maxHealth;

        RB = GetComponent<Rigidbody2D>();
        //SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        
    }

    public void changeAnim(states stateName)
    {
        anim.SetBool("RangeAttack", stateName == states.RangeAttack);
        anim.SetBool("MeleeAttack", stateName == states.MeleeAttack);
        anim.SetBool("Walk", stateName == states.Walk);
        anim.SetBool("Roll", stateName == states.Roll);
        anim.SetBool("Death", stateName == states.Death);
        anim.SetBool("Hit", stateName == states.Hit);
    }
}
