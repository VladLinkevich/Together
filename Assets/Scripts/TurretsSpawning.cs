using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsSpawning : MonoBehaviour
{
    private Transform mapTransform;

    public static int maxLevelSpawningTurrets;

    public GameObject turret;

    public float spawnTimeBetween;
    public float spawnTimeFirst;

    public float rangeX;
    public float rangeY;

    private Coroutine spawnCoroutine;

    private Vector2 lastSpawnPosition;
    private GameObject lastSpawnObject;

    private int countSpawningTurrets;

    void Start()
    {
        mapTransform = GetComponent<Transform>();
        maxLevelSpawningTurrets = 1;

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

    void stopSpawnTurrets()
    {
        StopCoroutine(spawnCoroutine);
    }

    private IEnumerator spawnTurretsCoroutine()
    {
        yield return new WaitForSeconds(spawnTimeFirst);

        while(true)
        {
            lastSpawnObject = Instantiate(turret, getRandomPosition(), Quaternion.identity);
            lastSpawnObject.transform.parent = mapTransform;

            countSpawningTurrets++;
            if (countSpawningTurrets != 0 && countSpawningTurrets % 5 == 0)
            {
                maxLevelSpawningTurrets++;
            }

            yield return new WaitForSeconds(spawnTimeBetween);
        }
    }
}
