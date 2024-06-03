using UnityEngine.UI;
using UnityEngine;

public class ActivaAAcheck : MonoBehaviour
{
    public Text text;
    public string prefName;
    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt(prefName, 1) == 1) text.text = "ON";
        else text.text = "OFF";
    }
}
