using UnityEngine;

[CreateAssetMenu(fileName = "New SerializeObject", menuName = "SerializeObject")]
public class SpawnEnemiesManager : ScriptableObject
{
    public GameObject prefabToSpawn;
    public Vector3[] spawnPoints;

    public new string name;
}
