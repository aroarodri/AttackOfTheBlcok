using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }
}
