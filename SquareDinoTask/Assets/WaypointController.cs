using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private int targetWaypointIndex = 0;
    public float speed = 3.0f;
    public Transform waypointPos;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        waypointPos = waypoints[targetWaypointIndex];
    }

    void Update()
    {
        agent.SetDestination(waypointPos.position);

        if (transform.position.x == waypointPos.position.x && transform.position.z == waypointPos.position.z && targetWaypointIndex != 5)
        {
            WaypointChange();

        }
    }

    void WaypointChange()
    {
        targetWaypointIndex += 1;
        waypointPos = waypoints[targetWaypointIndex];
    }
}
