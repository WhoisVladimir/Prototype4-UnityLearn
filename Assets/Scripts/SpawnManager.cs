using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject enemyPrefab;
    float spawnRange = 9f;
    int enemyCount;
    int waveNumber;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        float spawnPozX = Random.Range(-spawnRange, spawnRange);
        float spawnPozZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPozX, 0, spawnPozZ);
    }
}
