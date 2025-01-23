using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    private float lastSpawnTime;
    private float spawnDelay = 5;

    private void Update()
    {
        if (Time.time - lastSpawnTime > spawnDelay)
        {
            EnemyIndication.enemies.Add(Instantiate(enemyPrefab, spawnPoints[Random.Range(0, 4)].position, Quaternion.identity).transform);
            spawnDelay *= 0.9f;
            lastSpawnTime = Time.time;
        }
    }
}
