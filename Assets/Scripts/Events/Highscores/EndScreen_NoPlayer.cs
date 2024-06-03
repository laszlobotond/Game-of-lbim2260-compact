using UnityEngine.UI;
using UnityEngine;

public class EndScreen_NoPlayer : MonoBehaviour
{
    public ScoreCount scoreCount;
    [SerializeField] GameObject highScoreText,oldHighscoreInd;
    [SerializeField] Text scoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        int thisScore = scoreCount.score;
        scoreNumber.text = thisScore.ToString();
        if (thisScore > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", thisScore);
            highScoreText.SetActive(true);
        }
        else
        {
            oldHighscoreInd.SetActive(true);
        }
        
    }


}
