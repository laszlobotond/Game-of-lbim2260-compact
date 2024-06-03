using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    float initialHealth = 69f;
    float health;
    public GameObject self,explosion,enemyPrefab;
    AimAssist aa;
    public ScoreCount scoreCount;
    SNIPEreset sr;
    

    private void Start()
    {
        health = initialHealth;
        // self.GetComponent<MeshRenderer>().enabled = true;
        ShowOrHideBody(true);
        self.GetComponent<BoxCollider>().enabled = true;

        aa = GameObject.Find("AimAssister").GetComponent<AimAssist>();
        sr = GameObject.Find("SNIPE").GetComponent<SNIPEreset>();
    }

    public void TakesDamage(float damage)
    {
        health = health - damage;
        //Debug.Log(health);
        if (health <= 0) Die();
    }

    public void Die()
    {
        GameObject currentExplosion = Instantiate(explosion, self.transform.GetChild(2));
        Destroy(currentExplosion, 0.5f);
        // self.GetComponent<MeshRenderer>().enabled = false;
        ShowOrHideBody(false);
        self.GetComponent<BoxCollider>().enabled = false;
        scoreCount.IncreaseScore(10);
        Invoke ("MakeNewCopy",1f);

        if (Vector3.Distance(GameObject.Find("Player").transform.position,self.transform.position) > 17)
        {
            sr.DisplaySnipe();
        }

        Destroy(self,1.1f);
    }

    private void MakeNewCopy()
    {
        Vector3 nextPosition = new Vector3 (Random.Range(-20, 20),1,Random.Range(-20,20));
        GameObject spawnedEnemy = Instantiate(enemyPrefab,nextPosition,Quaternion.identity);
        aa.enemies[0] = spawnedEnemy.GetComponent<Transform>();
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
