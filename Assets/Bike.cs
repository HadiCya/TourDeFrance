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
    float maxMoveSpeed = 6.5f;
    public GameObject spawnPoint;

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector3>();
    }

    private void Update()
    {
        // move the bike
        rb.velocity += moveInput * moveScale;

        // cap horizontal movement speed to maxMoveSpeed
        var horizontalMovement = new Vector2(rb.velocity.x, rb.velocity.z);
        horizontalMovement = Vector2.ClampMagnitude(horizontalMovement, maxMoveSpeed);
        rb.velocity = new Vector3(horizontalMovement.x, rb.velocity.y, horizontalMovement.y);
    }

    // player dies, bike falls out of world, etc.
    public void TeleportToSpawn()
    {
        Debug.Log("Teleporting bike to spawn");
        transform.position = spawnPoint.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = new Vector3(0, -1, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
    }
}
