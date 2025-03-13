using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;
    Animator enemyAnimator;
    private AudioSource audioSource;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    
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
                enemyAnimator.SetTrigger("Enemy1Death");
                OnEnemyDied?.Invoke(10);
            }
            else if (CompareTag("Enemy2"))
            {
                enemyAnimator.SetTrigger("Enemy2Death");
                OnEnemyDied?.Invoke(25);

            }
            else if (CompareTag("Enemy3"))
            {
                enemyAnimator.SetTrigger("Enemy3Death");
                OnEnemyDied?.Invoke(50);
            }
            else if (CompareTag("Enemy4"))
            {
                enemyAnimator.SetTrigger("Enemy4Death");
                OnEnemyDied?.Invoke(100);
            }
        }
        if (Camera.main != null)
        {
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, Camera.main.transform.position);
        } 
        StartCoroutine(DestroyEnemy());
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
