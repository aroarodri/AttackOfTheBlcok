using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private List<GameObject> highScoreList;

    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    //highScoreList[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = topScores[i].ToString();

    // Update is called once per frame
    void Update()
    {
        score = (int)Time.time * 10;
        scoreText.text = "Score: " + score.ToString();
    }

    public int GetFinalScore()
    {
        return score;
    }

    // Metodo para guardar la puntuación en la lista de puntuaciones con PlayerRefs.
    public void SaveScore()
    {
        int currentScore = GetFinalScore();
        List<int> topScores = new List<int>();

        // Retrieve existing scores from PlayerPrefs
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("TopScore" + i))
            {
                topScores.Add(PlayerPrefs.GetInt("TopScore" + i));
            }
        }

        // Add the current score and sort the list
        topScores.Add(currentScore);
        topScores = topScores.OrderByDescending(x => x).Take(5).ToList();

        // Save the top 5 scores back to PlayerPrefs
        for (int i = 0; i < topScores.Count; i++)
        {
            PlayerPrefs.SetInt("TopScore" + i, topScores[i]);
        }

        PlayerPrefs.Save();

        for (int i = 0; i < topScores.Count; i++)
        {
            highScoreList[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = topScores[i].ToString();
        }
    }



    /* public void SaveScore()
     {
         List<int> topScores = new List<int>();

         for (int i = 0; i < highScoreList.Count; i++)
         {
             topScores.Add(int.Parse(highScoreList[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text));
         }

         topScores.Add(score);
         topScores = topScores.OrderByDescending(x => x).ToList();

         for (int i = 0; i < highScoreList.Count; i++)
         {
             highScoreList[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = topScores[i].ToString();
         }
     }*/
}
