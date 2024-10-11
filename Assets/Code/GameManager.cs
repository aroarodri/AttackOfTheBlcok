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
    private int finalScore = 3;

    // Metodo que controla la perdida de vidas del jugador.
    // Además, se encarga de generar un power up cuando el jugador pierde una vida.
    public void LoseHeart()
    {
        vidas--;

        if (vidas <= 0)
        {
            SaveScore();
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

    public void SaveScore()
    {
        ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();
        if (scoreCounter != null)
        {
            finalScore = scoreCounter.GetFinalScore();
            PlayerPrefs.SetInt("Score", finalScore);
            PlayerPrefs.Save();
        }
    }

    public List<int> GetHighScore()
    {
        List<int> scoresList = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            scoresList.Add(PlayerPrefs.GetInt("Score" + i));
        }

        scoresList.Sort((a, b) => b.CompareTo(a));


        return scoresList;
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
}
