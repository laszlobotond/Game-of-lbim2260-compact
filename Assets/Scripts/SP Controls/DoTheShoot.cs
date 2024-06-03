using UnityEngine;

public class DoTheShoot : MonoBehaviour
{
    public GameObject self,impactEffect,bomb,rifleShotSound,shotgunSound;
    public ParticleSystem rifleShot, rifleShot_assault,shotgunShot;
    public GameObject player;
    public float fireDelay,damage;
    public bool canShoot = true;
    int whichClass;
    GameObject currentBomb;

    void Start()
    {
        GetTheStats();
    }

    void GetTheStats()
    {
        whichClass = PlayerPrefs.GetInt("classChosen",1);
        if (whichClass == 1)
        {
            fireDelay = 0.2f;
            damage = 20f;
        }
        else if (whichClass == 2)
        {
            fireDelay = 1f;
            damage = 60f;
        }
        else if (whichClass == 3)
        {
            fireDelay = 1f;
            damage = 69f;
        }
        else
        {
            fireDelay = 2.5f;
            damage = 100f;
        }
    }

    void FixedUpdate()
    {
        if (canShoot)
        {
            if (whichClass == 1 || whichClass == 2) Shoot();
            else if (whichClass == 3) ShotgunShoot();
            else if (whichClass == 4) DemoShoot();
        }
        self.SetActive(false);
    }

    void Shoot()
    {
        canShoot = false;
        Invoke("canShootAgain", fireDelay);

        rifleShot.Play();
        rifleShot_assault.Play();
        GameObject rss = Instantiate(rifleShotSound);
        Destroy(rss, 1f);

        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, -player.transform.forward, out hit))
        {
            Enemy1 target = hit.transform.GetComponent<Enemy1>();
            Enemy2 target2 = hit.transform.GetComponent<Enemy2>();
            Enemy3 target3 = hit.transform.GetComponent<Enemy3>();
            if (target!=null)
            {
                target.TakesDamage(damage);
            }
            else if (target2!=null)
            {
                target2.TakesDamage(damage,hit);
            }
            else if (target3!=null)
            {
                target3.TakesDamage(damage, hit);
            }
            GameObject impactClone= Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactClone, 1f);
        }
    }

    void ShotgunShoot()
    {
        canShoot = false;
        Invoke("canShootAgain", fireDelay);

        shotgunShot.Play();
        GameObject rss = Instantiate(shotgunSound);
        Destroy(rss, 1f);

        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, -player.transform.forward, out hit))
        {
            Enemy1 target = hit.transform.GetComponent<Enemy1>();
            Enemy2 target2 = hit.transform.GetComponent<Enemy2>();
            Enemy3 target3 = hit.transform.GetComponent<Enemy3>();
            if (target != null)
            {
                if (Vector3.Distance(player.transform.position, target.self.transform.position) < 10)
                {
                    target.TakesDamage(damage);
                    showImpact(hit);
                }
            }
            else if (target2 != null)
            {
                if (Vector3.Distance(player.transform.position, target2.self.transform.position) < 10)
                {
                    target2.TakesDamage(damage, hit);
                    showImpact(hit);
                }
            }
            else if (target3 != null)
            {
                if (Vector3.Distance(player.transform.position, target3.self.transform.position) < 10)
                {
                    target3.TakesDamage(damage, hit);
                    showImpact(hit);
                }
            }
            
        }
    }

    void DemoShoot()
    {
        canShoot = false;
        Invoke("canShootAgain", fireDelay);

        //Spawning the bomb
        Transform playerTransform = player.GetComponent<Transform>();
        Vector3 currentPlayerPosition = new Vector3(playerTransform.position.x, 1.5f, playerTransform.position.z);
        currentBomb = Instantiate(bomb,currentPlayerPosition,Quaternion.identity);
        currentBomb.GetComponent<Collider>().enabled = false;
        Invoke("GiveHitbox", 0.1f);
        Destroy(currentBomb, 5f);

        //Throwing the bomb
        Rigidbody bombRb = currentBomb.GetComponent<Rigidbody>();
        bombRb.AddForce(-playerTransform.forward * 1200);
        bomb.GetComponent<Transform>().parent = null;
    }

    void GiveHitbox()
    {
        currentBomb.GetComponent<Collider>().enabled = true;
    }

    void showImpact(RaycastHit hit)
    {
        GameObject impactClone = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactClone, 1f);
    }

    void canShootAgain()
    {
        canShoot = true;
    }
}
