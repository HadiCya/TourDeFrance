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

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count == 0) return;

        if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < WPradius)
        {
            currentWP++;
            if(currentWP >= waypoints.Count)
            {
                currentWP = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWP].transform.position, Time.deltaTime * speed);
    }
}
