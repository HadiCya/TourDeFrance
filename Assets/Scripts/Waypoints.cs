using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    [SerializeField]
    int currentWP = 0;
    [SerializeField]
    float rotSpeed;
    public float speed;
    [SerializeField]
    float WPradius = 1;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < WPradius)
        {
            currentWP++;
            if(currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWP].transform.position, Time.deltaTime * speed);
    }
}
