using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;

    public Bullet bullet { get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        bullet = GetComponent<Bullet>();
    }
}
