using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private Transform turretTransform;

    public GameObject bullet;
    public float cooldown;
    [Space(15)]
    public int level;

    public Vector2 offset;

    private float currentCooldown;

    void Start()
    {
        turretTransform = GetComponent<Transform>();

        level = getRandomLevel();

        currentCooldown = cooldown;
    }

    private void Update()
    {
        if (currentCooldown < cooldown) currentCooldown += Time.deltaTime;
    }

    public void shoot()
    {
        if (currentCooldown >= cooldown)
        {
            currentCooldown = 0;
            BulletMovement bulletMov = Instantiate(bullet, turretTransform.position, Quaternion.identity).GetComponent<BulletMovement>();
            bulletMov.direction = turretTransform.right;
        }
    }

    public void addLevel()
    {
        level++;
        //animation
    }

    public void destroy()
    {
        Destroy(gameObject);
    }

    private int getRandomLevel()
    {
        return Random.Range(1, TurretsSpawning.maxLevelSpawningTurrets + 1);
    }
}
