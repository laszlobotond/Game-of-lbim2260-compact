using UnityEngine.UI;
using UnityEngine;

public class RefreshVolumeText : MonoBehaviour
{
    float currentVolume;
    public Text self;
    // Start is called before the first frame update
    void Start()
    {
        RefreshVolume();
    }

    public void RefreshVolume()
    {
        currentVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        self.text = (currentVolume).ToString();
    }
}
