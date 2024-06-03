using UnityEngine;

public class ChangeAA : MonoBehaviour
{
    public GameObject self;
    public string prefName;
    public int defaultValue = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt(prefName, 1) == 0)
        {
            PlayerPrefs.SetInt(prefName, 1);
        }
        else
        {
            PlayerPrefs.SetInt(prefName, 0);
        }
        //Debug.Log(PlayerPrefs.GetInt("AimAssist",1));
        self.SetActive(false);
    }
}
