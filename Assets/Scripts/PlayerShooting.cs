using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private Transform playerShootPoint;
    [SerializeField] private float shootIntervel;
    private float resetIntervel;

    void Start()
    {
        resetIntervel = shootIntervel;
    }

    void Update()
    {
        shootIntervel -= Time.deltaTime;
        if (shootIntervel <= 0)
        {
            Instantiate(laserBullet, playerShootPoint.position, playerShootPoint.rotation);
            shootIntervel = resetIntervel;
        }

    }
}
