using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private Enemy enemyScript;
    private bool isAttacking = false;

    public float attackAnimationDuration = 2.0f; // Adjust this based on your attack animation duration

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyScript = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (enemyScript.PlayerInAttackRange && !isAttacking)
        {
            // Set isAttacking to true to prevent Patrol animation
            isAttacking = true;

            // Trigger the Attack animation
            animator.SetTrigger("AttackRange");

            // Delay the reset until after the attack animation finishes
            Invoke(nameof(ResetAttackRange), attackAnimationDuration);
        }

        // Add your patrol logic here
        if (!isAttacking)
        {
            animator.SetBool("Patroling", true);
        }
        else
        {
            animator.SetBool("Patroling", false);
        }
    }

    private void ResetAttackRange()
    {
        // Reset the trigger and set isAttacking back to false
        animator.ResetTrigger("AttackRange");
        isAttacking = false;
    }
}

