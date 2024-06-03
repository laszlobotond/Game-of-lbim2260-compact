using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject thirdPersonCamera;
    public GameObject firstPersonCamera;
    private AimAssist aimAssister;
    private GameObject player;

    public void Start()
    {
        aimAssister = GameObject.Find("AimAssister").GetComponent<AimAssist>();
        player = GameObject.Find("Player");
    }

    public void changeActiveCamera()
    {
        thirdPersonCamera.SetActive(!thirdPersonCamera.activeSelf);
        firstPersonCamera.SetActive(!firstPersonCamera.activeSelf);

        // aim assist only in third person
        aimAssister.setAssistance(thirdPersonCamera.activeSelf);

        if (!thirdPersonCamera.activeSelf)
        {
            player.transform.eulerAngles = Vector3.zero;
        }
    }
}
