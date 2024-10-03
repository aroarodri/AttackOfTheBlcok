using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip homeMusic;

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
