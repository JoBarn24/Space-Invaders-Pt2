using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;
  private AudioSource audioSource;

  public float speed = 5;
    void Start()
    {
      myRigidbody2D = GetComponent<Rigidbody2D>();
      audioSource = GetComponent<AudioSource>();
      Fire();
    }

    private void Fire()
    {
      audioSource.PlayOneShot(audioSource.clip);
      myRigidbody2D.linearVelocity = Vector2.up * speed; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Barrier"))
      {
        Destroy(collision.gameObject);
      }
      
      Destroy(gameObject);
    }
}
