using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;
    private float health;
    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }

    public void PlayerTakeDamage(float damage)
    {
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if ((health / maxHealth) * 100 < 50)
        {
            healthFill.color = Color.red;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }
}
