using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;

    public ScoreCounter(int score)
    {
        this.score = score;
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score = (int) Time.time * 10;
        scoreText.text = "Score: " + score.ToString();
    }

    public int GetFinalScore()
    {
        return score;
    }
}
