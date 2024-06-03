using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    float initialHealth = 60f;
    float health;
    public GameObject self, explosion, enemyPrefab;
    AimAssist aa;
    public ScoreCount scoreCount;
    GameOver gameOver;
    SNIPEreset sr;

    private void Start()
    {
        gameOver = GameObject.Find("GameManager").GetComponent<GameOver>();
        aa = GameObject.Find("AimAssister").GetComponent<AimAssist>();
        sr = GameObject.Find("SNIPE").GetComponent<SNIPEreset>();

        health = initialHealth;
        // self.GetComponent<MeshRenderer>().enabled = true;
        ShowOrHideBody(true);
        self.GetComponent<BoxCollider>().enabled = true;

        Invoke("PushRandom", 3f);
    }

    public void TakesDamage(float damage, RaycastHit hit)
    {
        health = health - damage;
        //Debug.Log(health);
        if (health <= 0) Die();
        self.GetComponent<Rigidbody>().AddForce(hit.normal * -50f);
    }

    public void Die()
    {
        GameObject currentExplosion = Instantiate(explosion, self.transform.GetChild(2));
        Destroy(currentExplosion, 0.5f);
        // self.GetComponent<MeshRenderer>().enabled = false;
        ShowOrHideBody(false);
        self.GetComponent<BoxCollider>().enabled = false;
        scoreCount.IncreaseScore(15);
        Invoke("MakeNewCopy", 1f);

        if (Vector3.Distance(GameObject.Find("Player").transform.position, self.transform.position) > 17)
        {
            sr.DisplaySnipe();
        }
        
        //Destroy self after spawning new object
        Destroy(self, 1.1f);
    }

    void MakeNewCopy()
    {
        Vector3 nextPosition = new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20));
        GameObject spawnedEnemy = Instantiate(enemyPrefab, nextPosition, Quaternion.identity);
        aa.enemies[2] = spawnedEnemy.GetComponent<Transform>();
    }

    void PushRandom()
    {
        float x = Random.Range(-500, 500);
        float z = Random.Range(-500, 500);
        if (z > -150 && z <= 0) z = z - 150;
        else if (z < 150 && z > 0) z = z + 150;
        if (x > -150 && x <= 0) x = x - 150;
        else if (x < 150 && x > 0) x = x + 150;
        self.GetComponent<Rigidbody>().AddForce(x, 0, z);
        Invoke("PushRandom", 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            
            gameOver.EndTheGame();
        }
    }

    private void ShowOrHideBody(bool show) 
    {
        for (int i = 0; i < self.transform.childCount; i++)
        {
            GameObject childObj = self.transform.GetChild(i).gameObject;
            MeshRenderer mr = childObj.GetComponent<MeshRenderer>();
            if (mr != null) {
                mr.enabled = show;
            }
            else {
                childObj.SetActive(show);
            }
        }
    }
}
