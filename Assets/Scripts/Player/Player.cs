using UnityEngine;

public class Player : Entity
{
    [Header("Move info")]
    public float moveSpeed;
    public float jumpForce;
    private float defaultJumpForce;

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerWalkState walkState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerFallState fallState { get; private set; }
    #endregion

    protected override void Awake() {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        walkState = new PlayerWalkState(this, stateMachine, "Walk");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState  = new PlayerAirState(this, stateMachine, "Jump");
        // fallState = new PlayerFallState(this, stateMachine, "Jump");

    }

    protected override void Start() {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update() {
        base.Update();

        stateMachine.currentState.Update();
    }
}
