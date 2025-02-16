using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private Player player;

    private Vector2 finalDir;
    private void Start()
    {
        player = PlayerManager.instance.player;
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        finalDir = (mousePos - (Vector2)player.transform.position).normalized;
    }


    public void CreateBullet()
    {

        float bulletSpeed = 10f;
        int bulletDamage = 20; 

        GameObject newBullet = Instantiate(bulletPrefab, player.transform.position, transform.rotation);

        Bullet_Controller newBulletScript = newBullet.GetComponent<Bullet_Controller>();

        newBulletScript.Setup(finalDir, bulletSpeed, bulletDamage);
    }
}
