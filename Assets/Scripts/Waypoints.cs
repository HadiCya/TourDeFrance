using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject waypointsParent;
    public List<GameObject> waypoints;
    [SerializeField]
    int currentWP = 0;
    [SerializeField]
    float rotSpeed;
    public float speed;
    [SerializeField]
    float WPradius = 1;

    private void Awake()
    {
        foreach(Transform child in waypointsParent.transform)
        {
            waypoints.Add(child.gameObject);
        }

        waypoints.Reverse();
    }

    void Update()
    {
        if (waypoints.Count == 0) return;

        // if we get close enough to the target waypoint, start heading to next waypoint
        if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < WPradius)
        {
            currentWP++;
            if(currentWP >= waypoints.Count)
            {
                currentWP = 0;
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWP].transform.position, Time.deltaTime * speed);
        var q = Quaternion.LookRotation(waypoints[currentWP].transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * speed);
    }
}
