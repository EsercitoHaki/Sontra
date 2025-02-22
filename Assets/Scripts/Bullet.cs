using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    //[SerializeField] private float lifeTime = 3f;
    private bool hit;
    private bool canMove;
    private Animator anim;
    private CircleCollider2D circleCollider;
    [SerializeField] private Rigidbody2D rb;
    // public int damage = 10;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        // Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if (!hit)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Enemy"))
        // {
        //     // Gọi hàm gây sát thương
        //     collision.GetComponent<Enemy>()?.TakeDamage(damage);
        //     Destroy(gameObject);
        // }
        hit = true;
        circleCollider.enabled = false;
        anim.SetTrigger("Explode");
        rb.linearVelocity = Vector2.zero;
        // rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.parent = collision.transform;
        Invoke("DestroyMe", .4f);
    }
}
