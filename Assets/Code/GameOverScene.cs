using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameOverScene;

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
