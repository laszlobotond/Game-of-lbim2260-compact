using UnityEngine.UI;
using UnityEngine;

public class OldHS_Sharp : MonoBehaviour
{
    public Text oldHSnum;
    // Start is called before the first frame update
    void Start()
    {
        oldHSnum.text = PlayerPrefs.GetInt("SharpHighscore", 0).ToString() + ")";
    }
}
