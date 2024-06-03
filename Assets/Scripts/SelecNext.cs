using UnityEngine;

public class SelecNext : MonoBehaviour
{
    public int direction;
    bool canChange = true;
    public GameObject assault, sniper, shotgun, demo;
    GameObject[] classes = new GameObject[4];

    void Start()
    {
        classes[0] = assault;
        classes[1] = sniper;
        classes[2] = shotgun;
        classes[3] = demo;
        LoadThatCharacter();
    }


    void FixedUpdate()
    {
        if (canChange)
        {
            ChooseNext(direction);
            //Debug.Log(PlayerPrefs.GetInt("classChosen"));
        }
    }

    void ChooseNext(int direction)
    {
        canChange = false;
        int x = PlayerPrefs.GetInt("classChosen", 1);
        if (x == 4 && direction == 1) PlayerPrefs.SetInt("classChosen", 1);
        else if (x == 1 && direction == -1) PlayerPrefs.SetInt("classChosen", 4);
        else PlayerPrefs.SetInt("classChosen", x + direction);

        LoadThatCharacter();
        Invoke("canChooseAgain", 0.35f);
    }
    
    void canChooseAgain()
    {
        canChange = true;
    }

    void LoadThatCharacter()
    {
        for (int i=0;i<4;i=i+1)
        {
            if (i+1 != PlayerPrefs.GetInt("classChosen")) classes[i].SetActive(false);
            else classes[i].SetActive(true);
        }
    }

}
