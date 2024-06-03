using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    AudioSource musicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.volume = PlayerPrefs.GetFloat("MusicVolume",0.5f);
    }
}
