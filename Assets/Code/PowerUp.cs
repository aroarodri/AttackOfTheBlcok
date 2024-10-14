using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject powerUpToSpawn;
    [SerializeField] private GameObject powerUpToSpawn2;
    private Vector3 randomSpawnPoint = new();


    // Instanciar el GameObject en la posici�n aleatoria en un intervalo de tiempo aleatorio entre 1 y 3 segundos.
    public IEnumerator SpwanReducePowerUp()
    {
        float interval = Random.Range(1f, 3f);

        yield return new WaitForSeconds(interval);
        Instantiate(powerUpToSpawn, randomSpawnPoint, Quaternion.identity);
    }

    // Instanciar el GameObject en la posici�n aleatoria en un intervalo de tiempo aleatorio entre 1 y 3 segundos.
    public IEnumerator SpwanDestroyPowerUp()
    {
        float interval = Random.Range(1f, 3f);

        yield return new WaitForSeconds(interval);
        Instantiate(powerUpToSpawn2, randomSpawnPoint, Quaternion.identity);
    }


    // Generar un punto de spawn aleatorio dentro de los l�mites de la pantalla.
    public void GenerateSpawnPoint()
    {
        // Obtener los l�mites de la pantalla
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Convertir los l�mites de la pantalla a coordenadas del mundo
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, Camera.main.transform.position.z));

        // Generar una posici�n aleatoria dentro de los l�mites de la pantalla
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        float randomY = Random.Range(-screenBounds.y, screenBounds.y);

        // Crear una posici�n aleatoria para el PowerUp
        randomSpawnPoint = new Vector3(randomX, randomY, 0);
    }

}
