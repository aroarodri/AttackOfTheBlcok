using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Corazones;

    private int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
        }
    }

    // Método que se ejecuta cuando el jugador pierde el juego.
    public void Lose()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
    }

    public void ActivatePowerUp()
    {
        Debug.Log("PowerUp Activado");
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.transform.localScale *= 0.5f; // Reduce el tamaño del jugador a la mitad
            StartCoroutine(RestoreSizeAfterDelay(10f, player));
        }
    }

    private IEnumerator RestoreSizeAfterDelay(float delay, Player player)
    {
        yield return new WaitForSeconds(delay);
        player.transform.localScale = player.OriginalScale; // Restaurar el tamaño original del jugador
    }

    private void RestoreSizeAfterLosingHeart(Player player)
    {
        player.transform.localScale = player.OriginalScale; // Restaurar el tamaño original del jugador
    }
}
