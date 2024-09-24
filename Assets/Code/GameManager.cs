using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Método que se ejecuta cuando el jugador pierde el juego.
    public void Lose()
    {
        SceneManager.LoadScene("GameOver");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
