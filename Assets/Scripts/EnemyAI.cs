using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public LayerMask whatisGround, whatIsPlayer;
    public float health;
    public float moveSpeed;
    public float minDist;
    public float maxDist;
    public Vector3 startPos;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;



    private void Start()
    {
        transform.position = startPos;
        GameObject[] playerArray = GameObject.FindGameObjectsWithTag("Player");
        player = playerArray[0];
    }

    // Update is called once per frame
    private void Update()
    {
        Transform transformPlayer = player.transform;
        transform.LookAt(transformPlayer);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

        if (Vector3.Distance(transform.position, transformPlayer.position) >= minDist)
        {

            transform.position = Vector3.MoveTowards(transform.position, transformPlayer.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, transformPlayer.position) <= maxDist)
            {
                AttackPlayer();
            }

        }
    }

    private void AttackPlayer() {
        //transform.LookAt(player);

        if (!alreadyAttacked) {

            //Place Actual Attack here!
            Debug.Log("Attack player");

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        
        }
    }

    private void ResetAttack() {
        alreadyAttacked = false;
    }

    private void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            Invoke(nameof(DestroyEnemy), 2f);
        }
    }

    private void DestroyEnemy() {
        Destroy(gameObject);
    }
}
