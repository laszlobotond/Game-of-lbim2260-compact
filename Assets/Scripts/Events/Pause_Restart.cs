using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause_Restart : MonoBehaviour
{
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        transition.SetTrigger("Start");
        LoadAgain();
    }

    void LoadAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
