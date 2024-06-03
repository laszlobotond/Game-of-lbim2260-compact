using UnityEngine.UI;
using UnityEngine;

public class OldHS_SNOW : MonoBehaviour
{
    [SerializeField] Text oldHSnum;
    // Start is called before the first frame update
    void Start()
    {
        oldHSnum.text = PlayerPrefs.GetInt("SnowHighscore", 0).ToString() + ")";
    }
}
