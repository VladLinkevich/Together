using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsSpawning : MonoBehaviour
{
    private Transform mapTransform;

    public GameObject turret;

    public float spawnTimeBetween;
    public float spawnTimeFirst;

    public float rangeX;
    public float rangeY;

    private Coroutine spawnCoroutine;

    private Vector2 lastSpawnPosition;
    private GameObject lastSpawnObject;

    void Start()
    {
        mapTransform = GetComponent<Transform>();
        
        startSpawnTurrets();
    }

    private Vector2 getRandomPosition()
    {
        lastSpawnPosition.x = Random.Range(-rangeX, rangeX);
        lastSpawnPosition.y = Random.Range(-rangeY, rangeY);

        return lastSpawnPosition;
    }

    void startSpawnTurrets()
    {
        spawnCoroutine = StartCoroutine(spawnTurretsCoroutine());
    }

    private IEnumerator spawnTurretsCoroutine()
    {
        yield return new WaitForSeconds(spawnTimeFirst);

        while(true)
        {
            lastSpawnObject = Instantiate(turret, getRandomPosition(), Quaternion.identity);
            lastSpawnObject.transform.parent = mapTransform;
            yield return new WaitForSeconds(spawnTimeBetween);
        }
    }
}
