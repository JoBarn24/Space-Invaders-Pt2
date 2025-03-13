using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingOffset;
    public float shootInterval = 2f;
    public float bulletSpeed = 5f;
    public bool canShoot = false;

    private float shootTimer = 0f;

    Animator enemyAnimator;
    
    void Start()
    {
        if (gameObject.CompareTag("Enemy4"))
        {
            canShoot = true;
            shootInterval = Random.Range(6f, 10f);
            enemyAnimator = GetComponent<Animator>();
        }
        shootingOffset = transform.Find("ShootingOffset");
    }

    void Update()
    {
        if (!canShoot) return;
        
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            ShootBullet();
            shootTimer = 0f;
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingOffset.position, Quaternion.identity);

        if (bullet != null)
        {
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 direction = Vector2.down;
            rb.linearVelocity = direction * bulletSpeed;
            
            enemyAnimator.SetTrigger("EnemyShoot");

            Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(bulletCollider, GameObject.FindWithTag("Enemy1").GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(bulletCollider, GameObject.FindWithTag("Enemy2").GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(bulletCollider, GameObject.FindWithTag("Enemy3").GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(bulletCollider, GameObject.FindWithTag("Enemy4").GetComponent<Collider2D>());
        }
    }
}