using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f;
    // public int damage = 10;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Enemy"))
        // {
        //     // Gọi hàm gây sát thương
        //     collision.GetComponent<Enemy>()?.TakeDamage(damage);
        //     Destroy(gameObject);  // Hủy đạn sau khi va chạm
        // }
    }
}
