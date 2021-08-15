using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;

    private NavMeshAgent agent;
    private GameObject player;
    private Animator animator;
    private EnemyBase thisEnemy;

    private Vector3 dir;

    private void Start()
    {
        thisEnemy = GetComponent<EnemyBase>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
    }

    private void FixedUpdate()
    {
        if (thisEnemy.hasWon) return;

        Vector3 dir = player.transform.position - transform.position + new Vector3(0, 1, 0);
        int mask = 1 << 6;
        mask = ~mask;

        if(Physics.Raycast(transform.position, dir, out RaycastHit hit, 25, mask))
        {
            if (hit.collider.CompareTag("Player"))
            {
                animator.SetBool("isAlert", true);
                agent.speed = 3.5f;
                transform.LookAt(player.transform.position);
                dir = transform.position - player.transform.position;
                agent.destination = player.transform.position + (dir.normalized * 10f);
                thisEnemy.isAlert = true;

                if (hit.distance <= 11)
                {
                    thisEnemy.canAttack = true;
                }
            } else
            {
                animator.SetBool("isAlert", false);
                agent.speed = 1.25f;
                thisEnemy.isAlert = false;
                thisEnemy.canAttack = false;
            }
        }
        else
        {
            animator.SetBool("isAlert", false);
            agent.speed = 1.25f;
            thisEnemy.isAlert = false;
            thisEnemy.canAttack = false;
        }
    }

    private void GoToNextPoint()
    {
        agent.destination = patrolPoints[Random.Range(0, patrolPoints.Length - 1)].position;
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f && !thisEnemy.isAlert && !thisEnemy.hasWon)
            GoToNextPoint();
    }
}
