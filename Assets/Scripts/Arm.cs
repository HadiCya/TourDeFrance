using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    private Controls controls;
    public Transform customPivot;

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

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = controls.Player.Arm.ReadValue<Vector2>();
        transform.RotateAround(customPivot.position, new Vector3(0, direction.x), 100 * Time.deltaTime);
    }
}
