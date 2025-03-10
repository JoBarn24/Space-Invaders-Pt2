using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            if (CompareTag("Enemy1"))
            {
                OnEnemyDied?.Invoke(10);
            }
            else if (CompareTag("Enemy2"))
            {
                OnEnemyDied?.Invoke(20);

            }
            else if (CompareTag("Enemy3"))
            {
                OnEnemyDied?.Invoke(50);
            }
            else if (CompareTag("Enemy4"))
            {
                OnEnemyDied?.Invoke(100);
            }
        }
        
        Destroy(gameObject);
    }
}
