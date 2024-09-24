using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public SpawnEnemiesManager spawnManagerValues;

    private int numberOfSpawnPoints = 2;
    private Vector3 spawnAreaSize = new Vector3(10, 10, 10);
    private Vector3[] spawnPoints;

    private float spawnInterval = 10f; // Intervalo de tiempo para generar más enemigos
    private float timeSinceLastSpawn = 0f;

    private int nName;

    void Start()
    {
        GenerateSpawnPoints();
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (nName >= 10)
        {
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            timeSinceLastSpawn = 0f;
            GenerateSpawnPoints();
            SpawnEnemies();
        }
    }

    private void GenerateSpawnPoints()
    {
        spawnPoints = new Vector3[numberOfSpawnPoints];
        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
            float y = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
            float z = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);
            spawnPoints[i] = new Vector3(x, y, z);
        }
    }

    private void SpawnEnemies()
    {
        int currentSpawnPointIndex = 0;

        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            GameObject enemy = Instantiate(spawnManagerValues.prefabToSpawn, spawnPoints[currentSpawnPointIndex], Quaternion.identity);

            enemy.name = spawnManagerValues.name + nName;

            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnPoints.Length;

            nName++;
        }
    }
}
