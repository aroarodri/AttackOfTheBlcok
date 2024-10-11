using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    // Variables
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip homeMusic;
    [SerializeField] private List<GameObject> highScoreList;

    // Reproduce la música de fondo de la escena principal.
    void Start()
    {
        audioSource.clip = homeMusic;
        audioSource.Play();
        GetHighScore();
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

    public void GetHighScore()
    {
        List<int> scoresList = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("TopScore" + i))
                scoresList.Add(PlayerPrefs.GetInt("TopScore" + i));
        }

        scoresList.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < scoresList.Count; i++)
        {
            if (scoresList[i] > 0)
            {
                PlayerPrefs.SetInt("TopScore" + i, scoresList[i]);
            }

            highScoreList[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = scoresList[i].ToString();
            Debug.Log("Score " + i + ": " + scoresList[i]);
        }

    }

    public void ShowHighScores()
    {
        GameManager highScore = FindObjectOfType<GameManager>();

        List<int> scoresList = highScore.GetHighScore();

        for (int i = 0; i < scoresList.Count; i++)
        {
            highScoreList[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = scoresList[i].ToString();
            Debug.Log("Score " + i + ": " + scoresList[i]);
        }
    }
}
