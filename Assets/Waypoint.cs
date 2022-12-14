using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        terrain = FindObjectOfType<Terrain>();
        float waypointHeight = terrain.SampleHeight(transform.position);
        transform.position = new Vector3(transform.position.x, waypointHeight, transform.position.z);
    }
}
