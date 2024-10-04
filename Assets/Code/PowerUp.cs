using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Variables
    public GameObject powerUpToSpawn;
    private Vector3 randomSpawnPoint;


    // Instanciar el GameObject en la posición aleatoria en un intervalo de tiempo aleatorio entre 1 y 3 segundos.
    public IEnumerator SpwanPowerUp()
    {
        float interval = Random.Range(1f, 3f);

        yield return new WaitForSeconds(interval);
        Instantiate(powerUpToSpawn, randomSpawnPoint, Quaternion.identity);
    }

    // Generar un punto de spawn aleatorio dentro de los límites de la pantalla.
    public void GenerateSpawnPoint()
    {
        // Obtener los límites de la pantalla
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Convertir los límites de la pantalla a coordenadas del mundo
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, Camera.main.transform.position.z));

        // Generar una posición aleatoria dentro de los límites de la pantalla
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        float randomY = Random.Range(-screenBounds.y, screenBounds.y);

        // Crear una posición aleatoria para el PowerUp
        randomSpawnPoint = new Vector3(randomX, randomY, 0);
    }

}
