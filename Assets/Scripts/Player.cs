using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bulletPrefab;
  public GameObject playerPrefab;
  public Transform spawnPos;
  public Transform shootingOffset;
  public float input = 0f;
  public float speed = 1f;
  public delegate void PlayerDied();
  public static event PlayerDied OnPlayerDied;

  Animator playerAnimator;
  
  void Start()
  {
    playerAnimator = GetComponent<Animator>();
  }
  
  void Update()
  {
    if (Input.GetKey(KeyCode.A))
    {
      input = -1f;
    }

    if (Input.GetKey(KeyCode.D))
    {
      input = 1f;
    }
    
    Vector3 movement = new Vector3(input * speed * Time.deltaTime, 0f, 0f);
    transform.position += movement;
    
    float clampedX = Mathf.Clamp(transform.position.x, -9, 9);
    transform.position = new Vector3(clampedX, transform.position.y, 0f);
    
    if (Input.GetKeyDown(KeyCode.Space))
    { 
      playerAnimator.SetTrigger("Shoot Trigger");
      GameObject shot = Instantiate(bulletPrefab, shootingOffset.position, Quaternion.identity); 
      Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shot.GetComponent<Collider2D>());
      
      //Destroy(shot, 3f);
    }
  }
  
  void OnCollisionEnter2D(Collision2D collision)
  {
    Destroy(collision.gameObject);
    
    Destroy(gameObject);
    OnPlayerDied?.Invoke();
  }
}
