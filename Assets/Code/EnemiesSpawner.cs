using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    // Variables
    public SpawnEnemiesManager spawnManagerValues;

    private readonly int _numberOfSpawnPoints = 2;
    private Vector3 _spawnAreaSize = new(10, 10, 10);
    private Vector3[] _spawnPoints;

    private readonly float _spawnInterval = 10f; // Intervalo de tiempo para generar más enemigos
    private float _timeSinceLastSpawn = 0f;

    private int _nName;

    void Start()
    {
        GenerateSpawnPoints();
        SpawnEnemies();

        InvokeRepeating(nameof(SpawnEnemies), 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {


        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn >= _spawnInterval)
        {
            _timeSinceLastSpawn = 0f;
            GenerateSpawnPoints();
            SpawnEnemies();
        }
    }

    // Genera los puntos de spawn de los enemigos aleatoriamente.
    private void GenerateSpawnPoints()
    {
        _spawnPoints = new Vector3[_numberOfSpawnPoints];
        for (int i = 0; i < _numberOfSpawnPoints; i++)
        {
            float x = Random.Range(-_spawnAreaSize.x / 2, _spawnAreaSize.x / 2);
            float y = Random.Range(-_spawnAreaSize.y / 2, _spawnAreaSize.y / 2);
            float z = Random.Range(-_spawnAreaSize.z / 2, _spawnAreaSize.z / 2);
            _spawnPoints[i] = new Vector3(x, y, z);
        }
    }

    // Genera los enemigos en los puntos de spawn.
    private void SpawnEnemies()
    {
        GenerateSpawnPoints();
        int currentSpawnPointIndex = 0;

        if (_nName >= 10)
        {
            return;
        }

        for (int i = 0; i < _numberOfSpawnPoints; i++)
        {
            GameObject enemy = Instantiate(spawnManagerValues.prefabToSpawn, _spawnPoints[currentSpawnPointIndex], Quaternion.identity);

            enemy.name = spawnManagerValues.name + _nName;

            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % _spawnPoints.Length;

            _nName++;
        }
    }
}
