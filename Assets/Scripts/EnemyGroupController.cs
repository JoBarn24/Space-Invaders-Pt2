using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGroupController : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;
    public GameObject prefab;
    public int rows = 4;
    public int cols = 5;
    public float speed = 1f;
    public float speedIncreaseRate = 0.1f;

    private Vector3 direction = Vector3.right;
    private int totalEnemies = 0;

    void Start()
    {
        Enemy.OnEnemyDied += HandleEnemyDeath;
        SpawnEnemies();
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        float groupLeft = transform.position.x - (cols * 0.5f);
        float groupRight = transform.position.x + (cols * 0.5f);

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        if (direction == Vector3.right && groupRight >= rightEdge.x - 0.25f)
        {
            AdvanceRow();
        }
        else if (direction == Vector3.left && groupLeft <= leftEdge.x + 0.25f)
        {
            AdvanceRow();
        }

        if (totalEnemies <= 0)
        {
            SceneManager.LoadScene("CreditScene");
        }
    }

    void AdvanceRow()
    {
        direction.x *= -1f;

        Vector3 position = transform.position;
        position.y -= 1f;
        transform.position = position;
    }

    private void HandleEnemyDeath(int points)
    {
        speed += speedIncreaseRate;
        totalEnemies--;
        Debug.Log("Enemies Remaining: " + totalEnemies);
    }

    void OnDestroy()
    {
        Enemy.OnEnemyDied -= HandleEnemyDeath;
    }

    void SpawnEnemies()
    {
        totalEnemies = rows * cols;

        for (int row = 0; row < rows; row++)
        {
            float width = cols - 1;
            float height = rows - 1;
            Vector2 center = new Vector2(-width / 2, -height / 2 + 2f);
            Vector3 rowPos = new Vector3(center.x, center.y + row, 0f);

            if (row == 0)
            {
                prefab = enemy1Prefab;
            }
            else if (row == 1)
            {
                prefab = enemy2Prefab;
            }
            else if (row == 2)
            {
                prefab = enemy3Prefab;
            }
            else
            {
                prefab = enemy4Prefab;
            }

            for (int col = 0; col < cols; col++)
            {
                GameObject enemy = Instantiate(prefab, transform.position, Quaternion.identity);
                
                Vector3 position = rowPos;
                position.x += col;
                enemy.transform.localPosition = position;
                enemy.transform.parent = transform;
                
                EnemyShoot enemyShoot = enemy.AddComponent<EnemyShoot>();
                enemyShoot.shootingOffset = enemy.transform.Find("ShootingOffset");
            }
        }
    }
}