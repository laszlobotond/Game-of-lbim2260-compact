using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledManager : MonoBehaviour
{
    public DoTheShoot dts;
    public GameObject disabledOverlay;
    void FixedUpdate()
    {
        if (dts.canShoot) disabledOverlay.SetActive(false);
        else disabledOverlay.SetActive(true);
    }
}
