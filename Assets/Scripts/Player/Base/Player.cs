using UnityEngine;

public class Player : MonoBehaviour, IPlayerDamagable, IPlayerMoveable, IPlayerStateCheckable
{
    protected Animator anim;


    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; } = true;

    public bool IsMoving { get; set; }
    public bool IsAttacking { get; set; } 

    #region State Machine Variables

    public PlayerStateMachine StateMachine { get; set; }
    public PlayerIdleState IdleState { get; set; }
    public PlayerWalkState WalkState { get; set; }
    public PlayerAttackState AttackState { get; set; }


    #endregion

    #region ScriptAbleObject Variables

    [SerializeField] private PlayerIdleSOBase PlayerIdleBase;
    [SerializeField] private PlayerWalkSOBase PlayerWalkBase;
    [SerializeField] private PlayerAttackSOBase PlayerAttackBase;

    public PlayerIdleSOBase PlayerIdleBaseIntance { get; set; }
    public PlayerWalkSOBase PlayerWalkBaseIntance { get; set; }
    public PlayerAttackSOBase PlayerAttackBaseIntance { get; set; }

    #endregion

    public void Awake()
    {
        PlayerIdleBaseIntance = Instantiate(PlayerIdleBase);
        PlayerWalkBaseIntance = Instantiate(PlayerWalkBase);
        PlayerAttackBaseIntance = Instantiate(PlayerAttackBase);

        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine);
        WalkState = new PlayerWalkState(this, StateMachine);
        AttackState = new PlayerAttackState(this, StateMachine);

        this.anim = gameObject.GetComponent<Animator>();

    }

    private void Start()
    {
        CurrentHealth = MaxHealth;

        RB = GetComponent<Rigidbody2D>();

        PlayerIdleBaseIntance.Initialize(gameObject, this);
        PlayerWalkBaseIntance.Initialize(gameObject, this);
        PlayerAttackBaseIntance.Initialize(gameObject, this);

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentPlayerState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentPlayerState.PhysicsUpdate();
    }
    #region Health / Die Functions
    public void Damage(float damageamount)
    {
        CurrentHealth -= damageamount;
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    #endregion

    #region Movement Functions
    public void MovePlayer(Vector2 velocity)
    {
        RB.linearVelocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if (IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        if (!IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }
    #endregion

    #region AnimationTriggers
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentPlayerState.AnimationTriggerEvent(triggerType);
        if (triggerType == Player.AnimationTriggerType.PlayerIdle)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", false);
        }
        else if (triggerType == Player.AnimationTriggerType.PlayerWalk)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", true);
        }
        else if (triggerType == Player.AnimationTriggerType.PlayerAttack)
        {
            anim.SetBool("Attack", true);
            anim.SetBool("Walk", false);
        }
    }


    public enum AnimationTriggerType
    {
        PlayerDamaged,
        PlayerIdle,
        PlayerWalk,
        PlayerAttack
    }



    #endregion

    #region State Check
    public void SetMovingStatus(bool isMoving)
    {
        IsMoving = isMoving;
    }

    public void SetAttackingStatus(bool isAttacking)
    {
        IsAttacking = isAttacking;
    }
    #endregion

}




