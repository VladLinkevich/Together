using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [HideInInspector]public TurretShooting turretShooting;
    public bool randomRotate;

    public int level;

    public Vector2 offset;
    public Quaternion rotation;
    void Start()
    {
        turretShooting = GetComponent<TurretShooting>();

        if (randomRotate)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 3) * 90f);
            rotation = transform.rotation;
        }
        level = getRandomLevel();
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
