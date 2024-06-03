using UnityEngine.UI;
using UnityEngine;

public class Timer_Countdown : MonoBehaviour
{
    int timeLeft;
    GameObject textObject;
    public GameOver gameOver;
    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Timer");
        timeLeft = 100;
        textObject.GetComponent<Text>().text = timeLeft.ToString();
        Invoke("ReduceTimeLeft", 1f);
    }

    void ReduceTimeLeft()
    {
        timeLeft = timeLeft - 1;
        textObject.GetComponent<Text>().text = timeLeft.ToString();
        if (timeLeft == 0)
        {
            gameOver.EndTheGame();
        }
        else
        {
            Invoke("ReduceTimeLeft", 1f);
        }
    }
}
