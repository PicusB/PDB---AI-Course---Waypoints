using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    float speed = 5.0f;
    public float accuracy = 1.0f;
    public float rotSpeed = 2.0f;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[4];
    }
    
    public void GoToHeli()
    {
        if (wps[1])
        {
            g.AStar(currentNode, wps[1]);
            currentWP = 0;
        }
        else Debug.Log("There is nothing at waypoint 1");
    }

    public void GoToTower()
    {
        if (wps[8])
        {
            g.AStar(currentNode, wps[8]);
            currentWP = 0;
        }
        else Debug.Log("There is nothing at waypoint 8");
    }

    public void GoToRuinedTank()
    {
        if (wps[15])
        {
            g.AStar(currentNode, wps[15]);

            currentWP = 0;
        }
        else Debug.Log("There is nothing at waypoint 15");
    }

    public void GoBehindFactory()
    {
        if (wps[19])
        {
            g.AStar(currentNode, wps[19]);

            currentWP = 0;
        }
        else Debug.Log("There is nothing at waypoint 19");
    }
        void LateUpdate()
    {
        if (g.getPathLength() == 0 || currentWP == g.getPathLength())
        {
            return;
        }
        
        //the node we are closest to at this moment
        currentNode = g.getPathPoint(currentWP);

        //if we are close enough to the current waypoint move to the next
        if(Vector3.Distance(g.getPathPoint(currentWP).transform.position, transform.position)<accuracy)
        {
            currentWP++;
        }

        //if we are not at the end of the path
        if (currentWP < g.getPathLength())
        {
            goal = g.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            //Rotate
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            //Move
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
