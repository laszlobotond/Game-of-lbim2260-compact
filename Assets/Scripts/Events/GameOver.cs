using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    bool isInProgress = true;
    public GameObject endOverlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EndTheGame()
    {
        if (isInProgress)
        {
            endOverlay.SetActive(true);
            isInProgress = false;
        }
    }
}
