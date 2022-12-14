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
    public int playerID;
    public Vector3 startPos;
    PauseMenu pauseMenu;
    [SerializeField]
    Player player;

    [SerializeField]
    HealthBar player1HealthBar;
    [SerializeField]
    HealthBar player2HealthBar;

    private void Start()
    {
        transform.position = startPos;
        GameObject[] boundingbox = GameObject.FindGameObjectsWithTag("BoundingBox");
        gameObject.transform.SetParent(boundingbox[0].transform);
        transform.localPosition = new Vector3(0, 0, 0);
        pauseMenu = FindObjectOfType<PauseMenu>();

        player1HealthBar = GameObject.Find("P1HealthBar").GetComponent<HealthBar>();
        player2HealthBar = GameObject.Find("P2HealthBar").GetComponent<HealthBar>();

        if (player1HealthBar.player == null) player1HealthBar.player = player;
        else player2HealthBar.player = player;
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>() * moveScale;
    }

    private void OnPause()
    {
        if (pauseMenu.pausePanel == null)
        {
            Debug.Log("Pause panel is null, returning");
            return;
        }

        if (PauseMenu.isPaused)
        {
            pauseMenu.Unpause();
        }
        else
        {
            pauseMenu.Pause();
        }
    }

    private void Update()
    {
        
        // move the bike. Movement input should not be used for vertical (rb.y) velocity
        rb.velocity += new Vector3(moveInput.x, 0, moveInput.y);

        // cap horizontal movement speed to maxMoveSpeed
        var horizontalMovement = new Vector2(rb.velocity.x, rb.velocity.z);
        horizontalMovement = Vector2.ClampMagnitude(horizontalMovement, maxMoveSpeed);
        rb.velocity = new Vector3(horizontalMovement.x, rb.velocity.y, horizontalMovement.y);

        // rotate the bike towards the foward direction of the bounding area
        transform.localRotation = Quaternion.Euler(0, 90, 0);
    }

    // player dies, bike falls out of world, etc.
    public void TeleportToSpawn()
    {
        Debug.Log("Teleporting bike to spawn");
        transform.position = spawnPoint.transform.position;
        //transform.rotation = Quaternion.Euler(0, 90, 0);
        rb.velocity = new Vector3(0, -1, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
    }
}
