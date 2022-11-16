using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bike : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 moveInput;
    [SerializeField]
    float moveScale = 0.1f;

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector3>();
    }

    private void Update()
    {
        rb.velocity += moveInput * moveScale;
    }
}
