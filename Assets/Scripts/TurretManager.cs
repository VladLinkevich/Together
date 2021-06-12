using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [HideInInspector]public TurretShooting turretShooting;

    public int level;

    public Vector2 offset;
    void Start()
    {
        turretShooting = GetComponent<TurretShooting>();

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
