using UnityEngine;

public class Player : Entity
{
    [Header("Move info")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Bullet info")]
    public Transform firePoint;
    public GameObject bulletPrefab;

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerWalkState walkState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerFallState fallState { get; private set; }
    public PlayerRunState runState { get; private set;}

    public PlayerAttackState attackState { get; private set;}
    public PlayerShootState shootState { get; private set;}
    public PlayerRechargeState rechargeState {get; private set;}

    #endregion

    protected override void Awake() {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        walkState = new PlayerWalkState(this, stateMachine, "Walk");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState  = new PlayerAirState(this, stateMachine, "Jump");
        // fallState = new PlayerFallState(this, stateMachine, "Jump");
        runState = new PlayerRunState(this, stateMachine, "Run");
        attackState = new PlayerAttackState(this, stateMachine, "Attack");
        shootState = new PlayerShootState(this, stateMachine, "Shoot");
        rechargeState = new PlayerRechargeState(this, stateMachine, "Recharge");

    }

    protected override void Start() {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update() {
        base.Update();

        stateMachine.currentState.Update();
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}
