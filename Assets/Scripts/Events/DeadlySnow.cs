using UnityEngine;

public class DeadlySnow : MonoBehaviour
{
    float tempx,tempz,posx,posz;
    Transform player;
    public Material crimson, yellow;
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
        int x = Random.Range(1, 7);
        strx = x.ToString();
        str = "Snow (" + strx + ")";
    }

    void MakeItLethal()
    {
        GetNewRandomLine();
        currentDeadlyLine = GameObject.Find(str);
        if (currentDeadlyLine != null && (currentDeadlyLine.tag == "Snow"))
        {
            currentDeadlyLine.GetComponent<MeshRenderer>().material = yellow;
            canKill = false;
            Invoke("PaintCrimson", 1.5f);
            Invoke("MakeItBack", 5f);

            tempx = (currentDeadlyLine.GetComponent<Transform>().localScale.x) / 2;
            tempz = (currentDeadlyLine.GetComponent<Transform>().localScale.z) / 2;
            posx = (currentDeadlyLine.transform.position.x);
            posz = (currentDeadlyLine.transform.position.z);
        }
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
            if (currentDeadlyLine.tag == "Snow")
            {
                if ((player.position.x > posx - tempx) && (player.position.x < posx + tempx) && canKill && (player.position.z > posz-tempz) && (player.position.z < posz + tempz))
                {
                    gameOver.EndTheGame();
                }
            }
        }
    }
}
