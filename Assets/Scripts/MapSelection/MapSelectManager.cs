using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectManager : MonoBehaviour
{
    public GameObject[] images;
    public GameObject[] HsTexts;
    public GameObject[] specialTexts;
    public GameObject[] names;
    public CurrentMapHS currentMapHs;
    public int n = 0;
    void Start()
    {
        CheckSelectedMap(0);
    }

    public void CheckSelectedMap(int n)
    {
        for (int i=0;i<4;i++)
        {
            if (i==n)
            {
                images[i].SetActive(true);
                //HsTexts[i].SetActive(true);
                specialTexts[i].SetActive(true);
                names[i].SetActive(true);
            }
            else
            {
                images[i].SetActive(false);
                //HsTexts[i].SetActive(false);
                specialTexts[i].SetActive(false);
                names[i].SetActive(false);
            }
        }
        currentMapHs.CheckUpdatedHS(n);
    }
}
