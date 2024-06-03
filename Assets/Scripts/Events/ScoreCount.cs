using UnityEngine.UI;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public int score;
    public Text inGameScoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void IncreaseScore(int increaseValue)
    {
        score+=increaseValue;
        inGameScoreNumber.text = score.ToString();
    }
}
