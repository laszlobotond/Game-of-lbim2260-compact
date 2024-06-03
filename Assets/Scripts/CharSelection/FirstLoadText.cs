using UnityEngine;

public class FirstLoadText : MonoBehaviour
{
    public GameObject self;
    public GameObject assault, sniper, shotgun, demo;
    GameObject[] classes = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        classes[0] = assault;
        classes[1] = sniper;
        classes[2] = shotgun;
        classes[3] = demo;
        for (int i = 0; i < 4; i = i + 1)
        {
            if (i + 1 != PlayerPrefs.GetInt("classChosen", 1)) classes[i].SetActive(false);
            else classes[i].SetActive(true);
        }
        self.SetActive(false);
    }
}
