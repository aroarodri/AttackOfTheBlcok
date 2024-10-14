using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    [SerializeField] private List<GameObject> heartsList;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameSound;
    [SerializeField] private ScoreCounter scoreCounter;

    private int vidas = 3;

    // Metodo que controla la perdida de vidas del jugador.
    // Además, se encarga de generar un power up cuando el jugador pierde una vida.
    public void LoseHeart()
    {
        vidas--;

        if (vidas <= 0)
        {
            // Guarda la puntuación final del jugador.
            int currentScore = scoreCounter.GetFinalScore();
            scoreCounter.SaveScore(currentScore);
            Lose();
        }
        else
        {
            if (vidas > 0)
            {
                GameObject corazon = heartsList[vidas];
                //heartsList.RemoveAt(heartsList.Count - 1);
                corazon.SetActive(false);
                Player player = FindObjectOfType<Player>();
                if (player != null)
                    RestoreSizeAfterLosingHeart(player);
            }
            if (vidas == 2)
            {
                PowerUp powerUp = FindObjectOfType<PowerUp>();
                if (powerUp != null)
                {
                    powerUp.GenerateSpawnPoint();
                    StartCoroutine(powerUp.SpwanReducePowerUp());
                }
            }
            if (vidas == 1)
            {
                PowerUp powerUp = FindObjectOfType<PowerUp>();
                if (powerUp != null)
                {
                    powerUp.GenerateSpawnPoint();
                    StartCoroutine(powerUp.SpwanDestroyPowerUp());
                }
            }
        }
    }

    // Método que se ejecuta cuando el jugador pierde el juego.
    public void Lose()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
        scoreCounter.ResetScore();
    }

    // Método que se ejecuta cuando el jugador quiere volver a la pantalla principal.
    public void Home()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Home");
        scoreCounter.ResetScore();
    }

    // Método que activa el power up que reduce el tamaño a la mitad del jugador.
    public void ReducePlayerSizePowerUp()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.transform.localScale *= 0.5f;
            StartCoroutine(RestoreSizeAfterDelay(10f, player));
        }
    }

    // Método que destruye a todos los enemigos en pantalla.
    public void DestroyAllEnemiesPowerUp()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }

    // Corrutina que restaura el tamaño del jugador después de un tiempo determinado.
    private IEnumerator RestoreSizeAfterDelay(float delay, Player player)
    {
        yield return new WaitForSeconds(delay);
        player.transform.localScale = player.originalScale; // Restaurar el tamaño original del jugador
    }

    // Método que restaura el tamaño del jugador después de perder una vida y para la corrutina anterior.
    private void RestoreSizeAfterLosingHeart(Player player)
    {
        player.transform.localScale = player.originalScale; // Restaurar el tamaño original del jugador
        StopCoroutine(nameof(RestoreSizeAfterDelay));
    }

}
