using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private Player player;

    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float lifetime = 5f;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();

        rb.gravityScale = 0;
    }

    public void Setup(Vector2 direction, float _speed, int _dame)
    {
        speed = _speed;
        damage = _dame;

        rb.AddForce(direction.normalized * speed, ForceMode2D.Impulse);

        Destroy(gameObject, lifetime);
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            // if (enemy != null)
            // {
            //     enemy.TakeDamage(damage);
            // }
            
            Destroy(gameObject);
        }

        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    
}
