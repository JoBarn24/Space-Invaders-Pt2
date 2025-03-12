using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;

  public float speed = 5;
    void Start()
    {
      myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
    }

    private void Fire()
    {
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
