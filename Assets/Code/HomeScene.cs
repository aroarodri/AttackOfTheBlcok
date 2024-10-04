using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    // Variables
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip homeMusic;

    // Reproduce la música de fondo de la escena principal.
    void Start()
    {
        audioSource.clip = homeMusic;
        audioSource.Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
