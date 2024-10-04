using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    // Variables
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameOverScene;

    // Reproduce la música de fondo de la escena de Game Over.
    void Start()
    {
        audioSource.clip = gameOverScene;
        audioSource.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }
}
