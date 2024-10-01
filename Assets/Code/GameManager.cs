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
            reiniciarNivel();
            if (Corazones.Count > 0)
            {
                GameObject corazon = Corazones[Corazones.Count - 1];
                Corazones.RemoveAt(Corazones.Count - 1);
                corazon.SetActive(false);
            }
        }
    }

    public void reiniciarNivel()
    {
        /*ladrillosRestantes = GameObject.FindGameObjectsWithTag("Ladrillo").Length + GameObject.FindGameObjectsWithTag("DobleLadrillo").Length;

        FindObjectOfType<Bola>().reiniciarBola();
        FindObjectOfType<Jugador>().reiniciarJugador();*/

    }

    // Método que se ejecuta cuando el jugador pierde el juego.
    public void Lose()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
    }
}
