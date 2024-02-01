using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform leftCanon;
    [SerializeField] private Transform rightCanon;
    [SerializeField] private float speed;


    private float shootTimer = 0;
    [SerializeField] private float shootIntervel;

    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootIntervel <= shootTimer)
        {
            Instantiate(bulletPrefab, leftCanon.position, Quaternion.identity);
            Instantiate(bulletPrefab, rightCanon.position, Quaternion.identity);
            shootTimer = 0;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public override void DeathSequence()
    {
        Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            
        }
    }
}
