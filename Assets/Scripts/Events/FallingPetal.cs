using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPetal : MonoBehaviour
{
    public GameObject thisCube,thisCyl,thisLine;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            PetalDisappear(col, thisCube);
            PetalDisappear(col, thisCyl);
            PetalDisappear(col, thisLine);
        }
    }
    void PetalDisappear(Collision col,GameObject temp)
    {
        Physics.IgnoreCollision(col.collider, temp.GetComponent<Collider>());
        temp.GetComponent<MeshRenderer>().enabled = false;
    }
}
