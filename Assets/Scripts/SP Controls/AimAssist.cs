using UnityEngine;

public class AimAssist : MonoBehaviour
{
    public GameObject self;
    public Transform player;
    public Transform[] enemies;
    Transform tempTransform;
    bool shouldAssist;

    private void Start()
    {
        if (PlayerPrefs.GetInt("AimAssist", 1) == 1) shouldAssist = true;
        else shouldAssist = false;
    }

    void FixedUpdate()
    {
        tempTransform = GetClosestEnemy(enemies);
        if (tempTransform == null) return;
        if (tempTransform != player && shouldAssist) player.LookAt(2 * player.position - tempTransform.position);
    }

    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = player.position;

        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }

        if (minDist > 15) return player;
        return tMin;
    }

    public void setAssistance(bool assistEnabled)
    {
        if (PlayerPrefs.GetInt("AimAssist", 1) != 1)
        {
            shouldAssist = false;
            return;
        }
        shouldAssist = assistEnabled;
    }
}
