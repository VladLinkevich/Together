using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum turretType
{
    oneShoot,
    doubleShoot
}

public class TurretShooting : MonoBehaviour
{
    private Transform turretTransform;

    public GameObject bullet;
    public Transform[] bulletSpawnPoints;
    public float cooldown;
    public turretType type;

    private float currentCooldown;

    void Start()
    {
        turretTransform = GetComponent<Transform>();
        currentCooldown = cooldown;
    }

    void Update()
    {
        if (currentCooldown < cooldown) currentCooldown += Time.deltaTime;
    }

    public void shoot()
    {
        switch (type)
        {
            case turretType.oneShoot:
                if (currentCooldown >= cooldown)
                {
                    currentCooldown = 0;
                    BulletMovement bulletMov = Instantiate(bullet, bulletSpawnPoints[0].position, Quaternion.identity).GetComponent<BulletMovement>();
                    bulletMov.direction = turretTransform.right;
                }
                break;
            case turretType.doubleShoot:
                if (currentCooldown >= cooldown)
                {
                    currentCooldown = 0;
                    BulletMovement bulletMov = Instantiate(bullet, bulletSpawnPoints[0].position, Quaternion.identity).GetComponent<BulletMovement>();
                    bulletMov.direction = turretTransform.right;

                    bulletMov = Instantiate(bullet, bulletSpawnPoints[1].position, Quaternion.identity).GetComponent<BulletMovement>();
                    bulletMov.direction = turretTransform.right;
                }
                break;
        }       
    }
}
