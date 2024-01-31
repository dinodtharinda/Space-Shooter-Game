using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purpleBullet : MonoBehaviour
{
    [SerializeField] private float damege;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down *speed;
    }

   private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damege);
            Destroy(gameObject);
        }
   }

   private void OnBecameInvisible() {
    Destroy(gameObject);
   }
}