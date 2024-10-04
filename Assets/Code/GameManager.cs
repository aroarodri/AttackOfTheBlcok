using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    [SerializeField] private List<GameObject> Corazones;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameSound;

    private int vidas = 3;

    // Metodo que controla la perdida de vidas del jugador.
    // Adem�s, se encarga de generar un power up cuando el jugador pierde una vida.
    public void LoseHeart()
    {
        vidas--;

        if (vidas <= 0)
        {
            Lose();
        }
        else
        {
            if (Corazones.Count > 0)
            {
                GameObject corazon = Corazones[Corazones.Count - 1];
                Corazones.RemoveAt(Corazones.Count - 1);
                corazon.SetActive(false);
                Player player = FindObjectOfType<Player>();
                if (player != null)
                    RestoreSizeAfterLosingHeart(player);
            }
            if (Corazones.Count <= 2 && Corazones.Count >= 1)
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

    // M�todo que se ejecuta cuando el jugador pierde el juego.
    public void Lose()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
    }

    // M�todo que activa el power up que reduce el tama�o a la mitad del jugador.
    public void ActivatePowerUp()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.transform.localScale *= 0.5f;
            StartCoroutine(RestoreSizeAfterDelay(10f, player));
        }
    }

    // Corrutina que restaura el tama�o del jugador despu�s de un tiempo determinado.
    private IEnumerator RestoreSizeAfterDelay(float delay, Player player)
    {
        yield return new WaitForSeconds(delay);
        player.transform.localScale = player.OriginalScale; // Restaurar el tama�o original del jugador
    }

    // M�todo que restaura el tama�o del jugador despu�s de perder una vida.
    private void RestoreSizeAfterLosingHeart(Player player)
    {
        player.transform.localScale = player.OriginalScale; // Restaurar el tama�o original del jugador
    }
}
