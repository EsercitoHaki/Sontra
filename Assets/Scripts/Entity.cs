using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Collision infor")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;

    public int facingDir { get; private set; } = 1;
    public SpriteRenderer sr { get; private set; }
    public int knockbackDir { get; private set; }
    public CapsuleCollider2D cd {  get; private set; }

    //private bool facingRight = true;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public MovementController movementController { get; private set; }
    #endregion
    protected virtual void Awake() {

    }
    protected virtual void Start() {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movementController = new MovementController(rb, transform);
    }

    protected virtual void Update() {
        
    }

   #region Delegates for MovementController
    public void SetZeroVelocity() => movementController.SetZeroVelocity();

    public void SetVelocity(float xVelocity, float yVelocity) => movementController.SetVelocity(xVelocity, yVelocity);

    public void Flip() => movementController.Flip();

    public void SetupDefaultFacingDir(int direction) => movementController.SetupDefailtFacingDir(direction);
    #endregion

    #region Collision
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    protected virtual void OnDrawGizmos() {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }
    #endregion 
}
