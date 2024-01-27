using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private Transform basicShootPoint;

    [SerializeField] private float shootingIntervel;
    private float intervelRest;

    void Start()
    {
        intervelRest = shootingIntervel;
    }

    // Update is called once per frame
    void Update()
    {
        shootingIntervel -= Time.deltaTime;
        if (shootingIntervel <= 0)
        {
            Shoot();
            shootingIntervel = intervelRest;
        }
    }

    private void Shoot()
    {
        Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
    }
}
