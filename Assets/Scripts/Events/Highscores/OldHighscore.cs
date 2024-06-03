using UnityEngine.UI;
using UnityEngine;

public class OldHighscore : MonoBehaviour
{
    public Text oldHSnum;
    // Start is called before the first frame update
    void Start()
    {
        oldHSnum.text = PlayerPrefs.GetInt("Highscore", 0).ToString() + ")";
    }
}
