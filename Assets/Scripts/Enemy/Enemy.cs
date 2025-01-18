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
    [SerializeField] protected Transform lowWallCheck;
    [SerializeField] protected Transform hightWallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected Transform wallCheckFlip;
    [SerializeField] protected float wallCheckDistanceFlip;
    [SerializeField] protected Transform findCheckPlayer;
    [SerializeField] protected float findCheckPlayerDistance;
    [SerializeField] protected LayerMask whatIsPlayer;
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

        if (isWallDetected() && isHightWallDetected() && isWallFlipDetected())
        {
            Flip();
        }

        if ((isWallDetected() && isLowWallDetected() && !isHightWallDetected()) || ShouldJump())
        {
            SetVelocity(rb.linearVelocity.x, jumpForce);
        }

        if (isPlayerDetected())
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
    }

    public bool ShouldJump()
    {
        for (int i = 0; i < groundChecks.Length; i++)
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

        Gizmos.color = Color.red;
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
        Gizmos.DrawLine(lowWallCheck.position, new Vector3(lowWallCheck.position.x + wallCheckDistance * facingDir, lowWallCheck.position.y));
        Gizmos.DrawLine(hightWallCheck.position, new Vector3(hightWallCheck.position.x + wallCheckDistance * facingDir, hightWallCheck.position.y));
        Gizmos.DrawLine(wallCheckFlip.position, new Vector3(wallCheckFlip.position.x + wallCheckDistanceFlip * facingDir, wallCheckFlip.position.y));
        Gizmos.DrawLine(findCheckPlayer.position, new Vector3(findCheckPlayer.position.x + findCheckPlayerDistance * facingDir, findCheckPlayer.position.y));
    }
    
    public bool isPlayerDetected() => Physics2D.Raycast(findCheckPlayer.position, Vector2.right * facingDir, findCheckPlayerDistance, whatIsPlayer);

    #region WallCheck
    public bool isWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, groundLayer);
    public bool isLowWallDetected() => Physics2D.Raycast(lowWallCheck.position, Vector2.right * facingDir, wallCheckDistance, groundLayer);
    public bool isHightWallDetected() => Physics2D.Raycast(hightWallCheck.position, Vector2.right * facingDir, wallCheckDistance, groundLayer);
    public bool isWallFlipDetected() => Physics2D.Raycast(wallCheckFlip.position, Vector2.right * facingDir, wallCheckDistanceFlip, groundLayer);
    #endregion
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

        if (facingDir == -1)
        {
            facingRight = false;
        }
    }
    #endregion
}
