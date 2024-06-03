using UnityEngine.UI;
using UnityEngine;

public class EndScreen_SunFlower : MonoBehaviour
{
    public ScoreCount scoreCount;
    [SerializeField] GameObject highScoreText, oldHighscoreInd;
    [SerializeField] Text scoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        int thisScore = scoreCount.score;
        scoreNumber.text = thisScore.ToString();
        if (thisScore > PlayerPrefs.GetInt("FlowerHighscore", 0))
        {
            PlayerPrefs.SetInt("FlowerHighscore", thisScore);
            highScoreText.SetActive(true);
        }
        else
        {
            oldHighscoreInd.SetActive(true);
        }

    }
}
