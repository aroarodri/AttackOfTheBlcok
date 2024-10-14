using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    // Variables
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip homeMusic;
    [SerializeField] private TextMeshProUGUI[] highScoreList;

    // Reproduce la música de fondo de la escena principal.
    // Muestra las puntuaciones más altas guardadas en PlayerPrefs.
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("TopScore" + i))
            {
                int time = PlayerPrefs.GetInt("TopScore" + i);

                highScoreList[i].text = time.ToString();
            }
            else
            {
                highScoreList[i].text = "0";
            }
        }

        audioSource.clip = homeMusic;
        audioSource.Play();
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

