using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBullet : MonoBehaviour
{
    [SerializeField] private float damege;
    [SerializeField] private float speed;
   [SerializeField] private Rigidbody2D rb;
    void Start()
    {
     
        rb.velocity = transform.up *speed;
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
