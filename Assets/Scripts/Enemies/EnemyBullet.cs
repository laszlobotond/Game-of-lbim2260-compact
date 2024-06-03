using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject self,enemy2;
    Rigidbody bullet;
    [SerializeField] float enemyShotForce;
    GameOver gameOver;

    private void Start()
    {
        self.GetComponent<Collider>().enabled = false;
        Invoke("GiveHitbox", 0.5f);
        gameOver = GameObject.Find("GameManager").GetComponent<GameOver>();
        Transform player = GameObject.Find("Player").GetComponent<Transform>();
        Transform selfTransform = self.GetComponent<Transform>();
        bullet = self.GetComponent<Rigidbody>();
        float x = player.position.x - selfTransform.position.x;
        float z = player.position.z - selfTransform.position.z;
        bullet.AddForce(x * enemyShotForce, 0, z * enemyShotForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            gameOver.EndTheGame();
        }
    }

    void GiveHitbox()
    {
        self.GetComponent<Collider>().enabled = true;
    }
}
