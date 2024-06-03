using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCycleButon : MonoBehaviour
{
    public MapSelectManager msm;
    public int direction;
    int temp;
    public GameObject self;
    // Update is called once per frame
    void FixedUpdate()
    {
        temp = msm.n;
        if (temp == 3 && direction > 0) temp = 0;
        else
        {
            if (temp == 0 && direction < 0) temp = 3;
            else temp = temp + direction;
        }
        msm.n = temp;
        msm.CheckSelectedMap(temp);
        self.SetActive(false);
    }
}
