using UnityEngine;

[CreateAssetMenu(fileName = "New SerializeObject", menuName = "SerializeObject")]
public class SpawnEnemiesManager : ScriptableObject
{
    // Variables
    public GameObject prefabToSpawn;

    public new string name;
}
