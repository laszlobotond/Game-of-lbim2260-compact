using UnityEngine.UI;
using UnityEngine;

public class SNIPEreset : MonoBehaviour
{
    [SerializeField] Text self;
    GameObject floor;
    Material originalFloorMat;
    public Material fancyMat;
    ScoreCount sc;

    private void Start()
    {
        floor = GameObject.Find("Plane");
        originalFloorMat = floor.GetComponent<MeshRenderer>().material;
        sc = GameObject.Find("ScoreCounter").GetComponent<ScoreCount>();
    }

    public void DisplaySnipe()
    {
        //Write SNIPE on screen
        GameObject.Find("SNIPE").GetComponent<Text>().text = "SNIPE!";
        Invoke("HideSnipe", 1.5f);
        sc.IncreaseScore(50);

        //Make floor fancy
        floor.GetComponent<MeshRenderer>().material = fancyMat;
        Invoke("ResetFloorColor", 0.75f);
    }

    void HideSnipe()
    {
        self.text = " ";
    }

    void ResetFloorColor()
    {
        floor.GetComponent<MeshRenderer>().material = originalFloorMat;
    }
}
