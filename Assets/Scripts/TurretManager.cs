using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public int level;

    public Vector2 offset;

    void Start()
    {
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
