using UnityEngine.UI;
using UnityEngine;

public class CurrentMapHS : MonoBehaviour
{
    public GameObject self;
    Text text;
    void Start()
    {
        text = self.GetComponent<Text>();
        /*Debug.Log(PlayerPrefs.GetInt("Highscore"));
        Debug.Log(PlayerPrefs.GetInt("SnowHighscore"));
        Debug.Log(PlayerPrefs.GetInt("FlowerHighscore"));*/
    }

    public void CheckUpdatedHS(int n)
    {
        if (n == 0) text.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        else if (n == 1) text.text = PlayerPrefs.GetInt("SnowHighscore", 0).ToString();
        else if (n == 2) text.text = PlayerPrefs.GetInt("FlowerHighscore", 0).ToString();
        else if (n == 3) text.text = PlayerPrefs.GetInt("SharpHighscore", 0).ToString();
    }
}
