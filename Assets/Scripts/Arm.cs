using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Arm : MonoBehaviour
{
    private Controls controls;
    public Rigidbody rb;
    public float armSpeed;
    public Transform position;
    public GameObject RightShoulder;
    public Vector2 direction;

    #region InputSystem //Sets up player controls with input system
    private void Awake(){
        controls = new Controls();
    }
    private void OnEnable(){
        controls.Enable();
    }
    private void OnDisable(){
        controls.Disable();
    }
    #endregion

    private void OnArm(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(direction.x, 0, direction.y) * armSpeed;
        //Debug.Log(rb.velocity);
        //TODO: MAKE SO PLAYER CANNOT HOLD IN SAME GENERAL POSITION FOR LONGER THAN LIKE 0.1 SECOND
        RightShoulder.transform.position = Vector3.MoveTowards(RightShoulder.transform.position, position.position, armSpeed*100*Time.deltaTime);
        //Debug.Log(position.position);

    }

}
