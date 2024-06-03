using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    float initialHealth = 70f;
    float health;
    bool canStillShoot;
    public GameObject self, explosion, enemyPrefab,bullet;
    AimAssist aa;
    public ScoreCount scoreCount;
    GameObject thisBullet;
    SNIPEreset sr;

    private void Start()
    {
        canStillShoot = true;
        health = initialHealth;
        // self.GetComponent<MeshRenderer>().enabled = true;
        ShowOrHideBody(true);
        self.GetComponent<BoxCollider>().enabled = true;

        aa = GameObject.Find("AimAssister").GetComponent<AimAssist>();
        sr = GameObject.Find("SNIPE").GetComponent<SNIPEreset>();

        Invoke("PushRandom", 3f);
        Invoke("ShootBullet", 2f);
    }

    public void TakesDamage(float damage,RaycastHit hit)
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
        canStillShoot = false;
        scoreCount.IncreaseScore(20);
        Invoke("MakeNewCopy", 1f);

        if (Vector3.Distance(GameObject.Find("Player").transform.position, self.transform.position) > 17)
        {
            sr.DisplaySnipe();
        }

        Destroy(self, 1.1f);
    }

    void MakeNewCopy()
    {
        Vector3 nextPosition = new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20));
        GameObject spawnedEnemy = Instantiate(enemyPrefab, nextPosition, Quaternion.identity);
        aa.enemies[1] = spawnedEnemy.GetComponent<Transform>();
    }

    void PushRandom()
    {
        self.GetComponent<Rigidbody>().AddForce(Random.Range(-500, 500), 0, Random.Range(-500, 500));
        Invoke("PushRandom", 3f);
    }

    void ShootBullet()
    {
        Transform selfTransform = self.GetComponent<Transform>();
        Vector3 currentPosition = new Vector3(selfTransform.position.x, 1, selfTransform.position.z);
        if (canStillShoot)
        {
            thisBullet = Instantiate(bullet, currentPosition, Quaternion.identity);
        }

        Destroy(thisBullet, 2.5f);
        Invoke("ShootBullet", 4f);
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
