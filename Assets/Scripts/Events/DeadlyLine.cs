using UnityEngine;

public class DeadlyLine : MonoBehaviour
{
    float temp;
    Transform player;
    public Material crimson,yellow;
    public Material ownMat;
    string str, strx;
    GameObject currentDeadlyLine = null;
    GameOver gameOver;
    bool canKill;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.Find("GameManager").GetComponent<GameOver>();
        player = GameObject.Find("Player").GetComponent<Transform>();

        Invoke("MakeItLethal", 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckIfStepped();
    }

    void GetNewRandomLine()
    {
        int x = Random.Range(1, 87);
        strx = x.ToString();
        str = "Cube (" + strx + ")";
    }

    void MakeItLethal()
    {
        GetNewRandomLine();
        currentDeadlyLine = GameObject.Find(str);
        if (currentDeadlyLine != null && (currentDeadlyLine.tag == "VerticalEnvLine" || currentDeadlyLine.tag == "HorizontalEnvLine"))
        {
            currentDeadlyLine.GetComponent<MeshRenderer>().material = yellow;
            canKill = false;
            Invoke("PaintCrimson", 1.5f);
            Invoke("MakeItBack", 5f);
        }
        else MakeItLethal();
    }

    void PaintCrimson()
    {
        canKill = true;
        currentDeadlyLine.GetComponent<MeshRenderer>().material = crimson;
    }

    void MakeItBack()
    {
        currentDeadlyLine.GetComponent<MeshRenderer>().material = ownMat;
        currentDeadlyLine = null;
        Invoke("MakeItLethal", 5f);
    }

    void CheckIfStepped()
    {
        if (currentDeadlyLine != null)
        {
            if (currentDeadlyLine.tag == "VerticalEnvLine")
            {
                
                temp = currentDeadlyLine.GetComponent<Transform>().position.x;
                
                if ((player.position.x > temp - 0.75) && (player.position.x < temp + 0.75) && canKill)
                {
                    gameOver.EndTheGame();
                }
            }
            else
            {
                temp = currentDeadlyLine.GetComponent<Transform>().position.z;
                
                if (player.position.z > temp - 0.75 && player.position.z < temp + 0.75 && canKill)
                {
                    gameOver.EndTheGame();
                }
            }
        }
    }
}
