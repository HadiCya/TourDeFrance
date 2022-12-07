using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public LayerMask whatisGround, whatIsPlayer;
    public float health;
    public float moveSpeed;
    public float minDist;
    public float maxDist;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.Find("BMXBikeE").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(player);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);

        if (Vector3.Distance(transform.position, player.position) >= minDist)
        {

            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);



            if (Vector3.Distance(transform.position, player.position) <= maxDist)
            {
                AttackPlayer();
            }

        }
    }

    private void AttackPlayer() {
        //transform.LookAt(player);

        if (!alreadyAttacked) {

            //Place Actual Attack here!

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
