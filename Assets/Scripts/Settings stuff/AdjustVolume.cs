using System;
using UnityEngine;

public class AdjustVolume : MonoBehaviour
{
    public GameObject self;
    public int direction;
    public RefreshVolumeText rvt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        if ((x == 0) && direction < 0 || (x == 1) && direction > 0)
        {

        }
        else PlayerPrefs.SetFloat("MusicVolume",(float) Math.Round(x + (float) direction / 10, 2));
        rvt.RefreshVolume();
        self.SetActive(false);
    }
}
