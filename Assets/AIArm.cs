using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIArm : MonoBehaviour
{
    public Rigidbody rb;
    public float armSpeed;
    public Transform position;
    public GameObject RightShoulder;

    // Update is called once per frame
    void FixedUpdate()
    {
        System.Random rnd = new System.Random();
        Vector2 direction = new Vector2(rnd.Next(-2, 2), rnd.Next(-2, 2));
        rb.velocity = new Vector3(direction.x, 0, direction.y) * armSpeed;
        //Debug.Log(rb.velocity);
        //TODO: MAKE SO PLAYER CANNOT HOLD IN SAME GENERAL POSITION FOR LONGER THAN LIKE 0.1 SECOND
        RightShoulder.transform.position = Vector3.MoveTowards(RightShoulder.transform.position, position.position, armSpeed * 100 * Time.deltaTime);
        //Debug.Log(position.position);

    }

}