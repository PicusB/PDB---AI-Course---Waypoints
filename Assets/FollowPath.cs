using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour
{

    public GameObject wpManager;
    GameObject[] wps;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        agent = GetComponent<NavMeshAgent>();
    }
    
    public void GoToHeli()
    {
        if (wps[1])
        {
            agent.SetDestination(wps[1].transform.position);
        }
        else Debug.Log("There is nothing at waypoint 1");
    }

    public void GoToTower()
    {
        if (wps[8])
        {
            agent.SetDestination(wps[8].transform.position);
        }
        else Debug.Log("There is nothing at waypoint 8");
    }

    public void GoToRuinedTank()
    {
        if (wps[15])
        {
            agent.SetDestination(wps[15].transform.position);
        }
        else Debug.Log("There is nothing at waypoint 15");
    }

    public void GoBehindFactory()
    {
        if (wps[19])
        {
            agent.SetDestination(wps[19].transform.position);
        }
        else Debug.Log("There is nothing at waypoint 19");
    }
        void LateUpdate()
    {

    }
}
