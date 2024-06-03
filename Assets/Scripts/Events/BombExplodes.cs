using UnityEngine;

public class BombExplodes : MonoBehaviour
{
    [SerializeField] ParticleSystem bombExplosion,bombExplosion2;
    [SerializeField] GameObject self;
    AimAssist aa;

    private void Start()
    {
        aa = GameObject.Find("AimAssister").GetComponent<AimAssist>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy1" || collision.collider.tag == "Enemy2" || collision.collider.tag == "Enemy3")
        {
            bombExplosion.Play();
            bombExplosion2.Play();
            
            Enemy1 target = collision.collider.GetComponent<Enemy1>();
            Enemy2 target2 = collision.collider.GetComponent<Enemy2>();
            Enemy3 target3 = collision.collider.GetComponent<Enemy3>();
            if (target != null)
            {
                target.Die();
                if (Vector3.Distance(self.transform.position,aa.enemies[1].position) < 8)
                {
                    aa.enemies[1].root.GetComponent<Enemy2>().Die();
                }
                if (Vector3.Distance(self.transform.position, aa.enemies[2].position) < 8)
                {
                    aa.enemies[2].root.GetComponent<Enemy3>().Die();
                }
            }
            else
            {
                if (target2 != null)
                {
                    target2.Die();
                    if (Vector3.Distance(self.transform.position, aa.enemies[0].position) < 8)
                    {
                        aa.enemies[0].root.GetComponent<Enemy1>().Die();
                    }
                    if (Vector3.Distance(self.transform.position, aa.enemies[2].position) < 8)
                    {
                        aa.enemies[2].root.GetComponent<Enemy3>().Die();
                    }
                }
                else if (target3 != null)
                {
                    target3.Die();
                    if (Vector3.Distance(self.transform.position, aa.enemies[0].position) < 8)
                    {
                        aa.enemies[0].root.GetComponent<Enemy1>().Die();
                    }
                    if (Vector3.Distance(self.transform.position, aa.enemies[1].position) < 8)
                    {
                        aa.enemies[1].root.GetComponent<Enemy2>().Die();
                    }
                }
            }
            self.GetComponent<MeshRenderer>().enabled = false;
            Destroy(self, 1f);
        }
        
    }
}
