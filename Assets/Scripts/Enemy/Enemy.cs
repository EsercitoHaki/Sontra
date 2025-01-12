using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int facingDir { get; private set; } = 1;
    public SpriteRenderer sr { get; private set; }
    private bool facingRight = true;

    [Header("Move info")]
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float jumpForce;

    [Header("Collision infor")]
    [SerializeField] protected Transform[] groundChecks;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;

    
    Rigidbody2D rb;
    private bool[] isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = new bool[groundChecks.Length];
    }

    void Update()
    {
        SetVelocity(moveSpeed * facingDir, rb.linearVelocity.y);

        if (IsWallDetected())
        {
            Flip();
        }

        if (ShouldJump())
        {
            SetVelocity(rb.linearVelocity.x, jumpForce);
        }
    }

    public bool ShouldJump()
    {
        for(int i = 0; i < groundChecks.Length; i++)
        {
            isGrounded[i] = Physics2D.Raycast(groundChecks[i].position, Vector2.down, groundCheckDistance, groundLayer);
        }

        return !isGrounded[2] && !isGrounded[3] && isGrounded[4];
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.linearVelocity = new Vector2(_xVelocity, _yVelocity);
        
    }

    void OnDrawGizmosSelected()
    {
        if (groundChecks != null)
        {
            Gizmos.color = Color.green;
            foreach (Transform check in groundChecks)
            {
                Gizmos.DrawLine(check.position, new Vector3(check.position.x, check.position.y - groundCheckDistance));
            }
        }

        if (wallCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
        }
    }

    public bool IsWallDetected()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, groundLayer);
    }

    #region Flip
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
        {
            Flip();
        }
        else if (_x < 0 && facingRight)
        {
            Flip();
        }
    }

    public virtual void SetupDefailtFacingDir(int _direction)
    {
        facingDir = _direction;
        
        if(facingDir == -1)
        {
            facingRight = false;
        }
    }
    #endregion
}
