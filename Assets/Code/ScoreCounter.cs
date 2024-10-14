using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    // Variables
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

    // M�todo para actualizar la puntuaci�n por tiempo.
    void Update()
    {
        score = (int) Time.time * 10;
        scoreText.text = "Score: " + score.ToString();
    }

    // M�todo para devolver el valor de la puntuaci�n.
    public int GetFinalScore()
    {
        return score;
    }

    // M�todo para reiniciar la puntuaci�n.
    public void ResetScore()
    {
        score = 0;
    }

    // Metodo para guardar la puntuaci�n en la lista de puntuaciones con PlayerRefs.
    public void SaveScore(int currentScore)
    {

        List<int> topScores = new List<int>();

        // Obtiene las puntuaciones guardadas en PlayerPrefs
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("TopScore" + i))
            {
                topScores.Add(PlayerPrefs.GetInt("TopScore" + i));
            }
        }

        // A�ade la puntuaci�n actual y ordena la lista
        topScores.Add(currentScore);
        topScores = topScores.OrderByDescending(x => x).Take(5).ToList();

        // Guarda las 5 mejores puntuaciones en PlayerPrefs
        for (int i = 0; i < topScores.Count; i++)
        {
            PlayerPrefs.SetInt("TopScore" + i, topScores[i]);
        }

        PlayerPrefs.Save();
    }

    public void UpdateTopTimes(float newTime)
    {
        // Cargar los tiempos guardados
        List<float> topTimes = new List<float>();

        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("TopTime" + i))
            {
                topTimes.Add(PlayerPrefs.GetFloat("TopTime" + i));
            }
        }

        // A�adir el nuevo tiempo
        topTimes.Add(newTime);

        // Ordenar los tiempos de mayor a menor
        topTimes.Sort((a, b) => b.CompareTo(a));

        // Guardar los 5 mejores tiempos
        for (int i = 0; i < 5; i++)
        {
            if (i < topTimes.Count)
            {
                PlayerPrefs.SetFloat("TopTime" + i, topTimes[i]);
            }
        }

        PlayerPrefs.Save();
    }
}
