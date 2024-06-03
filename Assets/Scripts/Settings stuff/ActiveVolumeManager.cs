using UnityEngine;

public class ActiveVolumeManager : MonoBehaviour
{
    AudioSource musicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();  
    }

    private void FixedUpdate()
    {
        musicPlayer.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
}
