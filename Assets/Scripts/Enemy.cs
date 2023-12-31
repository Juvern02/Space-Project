using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Health playerHealth;
    public ThirdPersonController thirdPersonController;

    public bool PlayerInAttackRange = false;
    public bool PlayerPatroling = false;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake() {
        player = GameObject.Find("Skeleton").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        // check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling(){
        PlayerInAttackRange = false;
        PlayerPatroling = true;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // WalkPoint Reached

        if (distanceToWalkPoint.magnitude < 1f)
        walkPointSet = false;
    }

    private void SearchWalkPoint(){

        // calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y,
         transform.position.z + randomZ);

         if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
         walkPointSet = true;
    }

    private void ChasePlayer(){
        PlayerPatroling = true;
        PlayerInAttackRange = false;
        agent.SetDestination(player.position);
    }

    private void AttackPlayer(){
        PlayerPatroling = false;
        PlayerInAttackRange = true;
        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked){

            // Attack code here
            thirdPersonController.damagePlayer(20f);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack(){
        alreadyAttacked = false;

    }
}
