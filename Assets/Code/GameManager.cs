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

    private int vidas = 3;
    private int finalScore = 0;

    // Metodo que controla la perdida de vidas del jugador.
    // Además, se encarga de generar un power up cuando el jugador pierde una vida.
    public void LoseHeart()
    {
        vidas--;

        if (vidas <= 0)
        {
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
            if (vidas <= 2 && vidas >= 1)
            {
                PowerUp powerUp = FindObjectOfType<PowerUp>();
                if (powerUp != null)
                {
                    powerUp.GenerateSpawnPoint();
                    StartCoroutine(powerUp.SpwanPowerUp());
                }
            }
        }
    }

    // Método que se ejecuta cuando el jugador pierde el juego.
    public void Lose()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
    }

    public void Home()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Home");
    }

    // Método que activa el power up que reduce el tamaño a la mitad del jugador.
    public void ActivatePowerUp()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.transform.localScale *= 0.5f;
            StartCoroutine(RestoreSizeAfterDelay(10f, player));
        }
    }

    // Método que activa el power up que convierte al jugador en atacante y puede eliminar a los enemigos.
    public void ActivatePowerUp2()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            Enemy enemy = FindObjectOfType<Enemy>();
            if (enemy != null)
                StartCoroutine(DeactivateAttackerMode(5f, enemy));
        }
    }

    // Corrutina que restaura el tamaño del jugador después de un tiempo determinado.
    private IEnumerator RestoreSizeAfterDelay(float delay, Player player)
    {
        yield return new WaitForSeconds(delay);
        player.transform.localScale = player.originalScale; // Restaurar el tamaño original del jugador
    }

    // Método que restaura el tamaño del jugador después de perder una vida.
    private void RestoreSizeAfterLosingHeart(Player player)
    {
        player.transform.localScale = player.originalScale; // Restaurar el tamaño original del jugador
    }

    private IEnumerator DeactivateAttackerMode(float delay, Enemy enemy)
    {
        yield return new WaitForSeconds(delay);
        enemy.isAttackerMode = false;
    }
}
