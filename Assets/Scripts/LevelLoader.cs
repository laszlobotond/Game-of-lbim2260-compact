using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string nextSceneName;
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        transition.SetTrigger("Start");
        Invoke("GoToNext", 1f);
    }

    void GoToNext()
    {
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}