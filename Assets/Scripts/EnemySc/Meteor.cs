using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    [SerializeField] private float rotateSpeed;
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);

        rb.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public override void HurtSequence()
    {
        base.HurtSequence();
    }

    public override void DeathSequence()
    {
        Destroy(gameObject);
        Instantiate(explosionPrefab,transform.position,transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.CompareTag("Player"))
        {
            PlayerStats player = otherColl.GetComponent<PlayerStats>();
            player.PlayerTakeDamage(damage);
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
