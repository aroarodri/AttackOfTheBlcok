using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    // Variables
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip homeMusic;
    [SerializeField] private ScoreCounter scoreCounter;

    // Reproduce la música de fondo de la escena principal.
    void Start()
    {
        if (scoreCounter != null)
        {
            scoreCounter.SaveScore();
        }

        audioSource.clip = homeMusic;
        audioSource.Play();
    }

    private void FixedUpdate()
    {

    }


    public void StartGame()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

