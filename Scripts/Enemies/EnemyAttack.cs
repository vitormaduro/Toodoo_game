using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DigitalRuby.LightningBolt;

public class EnemyAttack : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    private NavMeshAgent agent;
    private EnemyBase thisEnemy;
    private GameObject lightningPrefab;
    private GameObject activeLightning;
    private Transform projectileSpawnPoint;

    public float attackCooldown;

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
        if (!agent.pathPending && agent.remainingDistance < 0.5f && thisEnemy.canAttack && attackCooldown >= 3f)
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
        Vector3 dir = player.transform.position - transform.position + new Vector3(0, 1, 0);
        Vector3 hitModifier = new Vector3(Random.Range(-1.5f, 1.5f), 0, 0);

        Physics.Raycast(transform.position, dir + hitModifier, out RaycastHit hit, Mathf.Infinity);
        activeLightning = Instantiate(lightningPrefab, projectileSpawnPoint.transform.position, Quaternion.identity);

        LightningBoltScript lightningParams = activeLightning.GetComponent<LightningBoltScript>();
        lightningParams.StartObject.transform.position = projectileSpawnPoint.transform.position;
        lightningParams.EndObject.transform.position = hit.transform.position + new Vector3(0, 1, 0);

        Destroy(activeLightning, 0.5f);
    }
}
