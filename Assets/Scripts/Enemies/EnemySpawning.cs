using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    private float lastSpawnTime;
    private float spawnDelay = 5;

    private void Update()
    {
        if (Time.time - lastSpawnTime > spawnDelay)
        {
            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, 3)], spawnPoints[Random.Range(0, 4)].position, Quaternion.identity);
            EnemyIndication.enemies.Add(enemy.transform);
            enemy.GetComponent<PathFollow>().path = GameObject.Find("Paths").GetComponent<WaypointManager>();
            spawnDelay *= 0.95f;
            lastSpawnTime = Time.time;
        }
    }
}
