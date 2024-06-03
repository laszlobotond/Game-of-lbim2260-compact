using UnityEngine.UI;
using UnityEngine;

public class OldHS_SunFlower : MonoBehaviour
{
    [SerializeField] Text oldHSnum;
    // Start is called before the first frame update
    void Start()
    {
        oldHSnum.text = PlayerPrefs.GetInt("FlowerHighscore", 0).ToString() + ")";
    }
}
