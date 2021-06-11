using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public int level;

    public Vector2 offset;

    void Start()
    {
        
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
}
