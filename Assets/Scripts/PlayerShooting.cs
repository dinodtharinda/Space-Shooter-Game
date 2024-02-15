using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private float shootingIntervel;

    [Header("Basic Attack")]
    [SerializeField] private Transform basicShootPoint;

    [Header("Update Points")]
    [SerializeField] private Transform leftCanon;
    [SerializeField] private Transform rightCanon;
    [SerializeField] private Transform secondLeftCanon;
    [SerializeField] private Transform secondRightCanon;

    [Header("Update Rotation Points")]
    [SerializeField] private Transform leftRotationCanon;
    [SerializeField] private Transform rightRotationCanon;

    private int upgradeLevel = 0;



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

    public void IncreaseUpdate(int increaseAmount)
    {
        upgradeLevel += increaseAmount;
        if (upgradeLevel > 4)
        {
            upgradeLevel = 4;
        }
    }

    public void DecreaseUpdate()
    {
        upgradeLevel -= 1;
        if (upgradeLevel < 0)
        {
            upgradeLevel = 0;
        }
    }

    private void Shoot()
    {

        switch (upgradeLevel)
        {
            case 0:
                Instantiate(laserBullet, basicShootPoint.position, transform.rotation);
                break;
            case 1:
                Instantiate(laserBullet, leftCanon.position, transform.rotation);
                Instantiate(laserBullet, rightCanon.position, transform.rotation);
                break;
            case 2:
                Instantiate(laserBullet, basicShootPoint.position, transform.rotation);
                Instantiate(laserBullet, leftCanon.position, transform.rotation);
                Instantiate(laserBullet, rightCanon.position, transform.rotation);
                break;
            case 3:
                Instantiate(laserBullet, basicShootPoint.position, transform.rotation);
                Instantiate(laserBullet, leftCanon.position, transform.rotation);
                Instantiate(laserBullet, rightCanon.position, transform.rotation);
                Instantiate(laserBullet, secondLeftCanon.position, transform.rotation);
                Instantiate(laserBullet, secondRightCanon.position, transform.rotation);
                break;
            case 4:
                Instantiate(laserBullet, basicShootPoint.position, transform.rotation);
                Instantiate(laserBullet, leftCanon.position, transform.rotation);
                Instantiate(laserBullet, rightCanon.position, transform.rotation);
                Instantiate(laserBullet, secondLeftCanon.position, transform.rotation);
                Instantiate(laserBullet, secondRightCanon.position, transform.rotation);
                Instantiate(laserBullet, leftRotationCanon.position, leftRotationCanon.rotation);
                Instantiate(laserBullet, rightRotationCanon.position, rightRotationCanon.rotation);
                break;
            default:
                break;

        }


    }
}
