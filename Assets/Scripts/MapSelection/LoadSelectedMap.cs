using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSelectedMap : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] MapSelectManager msm;

    void Start()
    {
        transition.SetTrigger("Start");
        Invoke("LoadChosenMap", 1.0f);
    }

    void LoadChosenMap()
    {
        if (msm.n==0) SceneManager.LoadScene("SP_Retro", LoadSceneMode.Single);
        else if (msm.n==1) SceneManager.LoadScene("SP_Winter", LoadSceneMode.Single);
        else if (msm.n == 2) SceneManager.LoadScene("SP_SunFlower", LoadSceneMode.Single);
        else SceneManager.LoadScene("SP_SharpMovement", LoadSceneMode.Single);
    }
}
