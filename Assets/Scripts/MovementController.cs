using UnityEngine;

public class MovementController
{
    private Rigidbody2D rb;
    private Transform transform;
    private int facingDir = 1;
    private bool facingRight = true;

    public MovementController(Rigidbody2D _rb, Transform _transform)
    {
        this.rb = _rb;
        this.transform = _transform;
    }


    #region Velocity
    public virtual void SetZeroVelocity()
    {
        rb.linearVelocity = new Vector2(0, 0);
    }

    public virtual void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.linearVelocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
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
