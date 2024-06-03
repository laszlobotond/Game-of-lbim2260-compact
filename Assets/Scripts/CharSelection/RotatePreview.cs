using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePreview : MonoBehaviour
{
    public Transform player;
    public int rotateDirection;
    // Update is called once per frame
    void FixedUpdate()
    {
        player.Rotate(0, rotateDirection, 0);
    }
}
