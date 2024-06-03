using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseOverlay;

    void Update()
    {
        if (pauseOverlay.activeSelf) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
