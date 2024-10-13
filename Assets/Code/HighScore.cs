using UnityEngine;

public class HighScore : MonoBehaviour
{
    private int highScore;

    private void Start()
    {
        SetLatestHighScore();
    }

    private void SetLatestHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    public void SetHighScoreIfGreater(int score)
    {
        if (highScore < score)
        {
            highScore = score;
            SaveHighScore(score);
        }
    }
}