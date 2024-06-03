using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform mycamera, player;
    public int offset_y = 5, offset_z = 5,offset_x = 5,followAll=0;


    private void Start()
    {
        if (PlayerPrefs.GetInt("CamFollowAll", 0) == 1) followAll = 1;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        mycamera.LookAt(player);
        
        mycamera.position = new Vector3(followAll * player.position.x, offset_y, player.position.z + offset_z);
    }
}
