using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    private NavMeshAgent agent;
    private EnemyBase thisEnemy;
    private GameObject lightningPrefab;
    private GameObject activeLightning;
    private Transform projectileSpawnPoint;

    private float attackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        thisEnemy = GetComponent<EnemyBase>();
        lightningPrefab = Resources.Load<GameObject>("Lightning");
        projectileSpawnPoint = transform.Find("ProjectileSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f && thisEnemy.canAttack && attackCooldown >= 1f)
        {
            animator.SetBool("isAttacking", true);
            attackCooldown = 0;
        }

        if(!thisEnemy.canAttack)
        {
            animator.SetBool("isAttacking", false);
        }

        attackCooldown += Time.deltaTime;
    }

    public void ShootLightning()
    {
        activeLightning = Instantiate(lightningPrefab, projectileSpawnPoint.transform.position, Quaternion.identity);
        activeLightning.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().StartPosition = projectileSpawnPoint.transform.position;
        activeLightning.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().EndPosition = player.transform.position;

        Destroy(activeLightning, 0.5f);
    }
}
