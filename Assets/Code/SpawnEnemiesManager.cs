using UnityEngine;

[CreateAssetMenu(fileName = "New SerializeObject", menuName = "SerializeObject")]
public class SpawnEnemiesManager : ScriptableObject
{
    // Variables
    public GameObject prefabToSpawn;
    public GameObject prefabToSpawn2;

    public new string name;
}
