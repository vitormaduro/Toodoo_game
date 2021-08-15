using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private GameObject fireballPrefab;
    private GameObject projectile;
    private GameObject defendAuraPrefab;
    private GameObject activeAura;
    private Transform projectileSpawnPoint;
    private PlayerBase player;

    public bool hasMagic = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerBase>();
        animator = gameObject.GetComponent<Animator>();
        fireballPrefab = Resources.Load<GameObject>("Fireball");
        projectileSpawnPoint = transform.Find("ProjectileSpawn");
        defendAuraPrefab = Resources.Load<GameObject>("DefendAura");
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.canAttack) return;
        if (!hasMagic) return;

        if(Input.GetButtonDown("Fire2") && player.canAttack)
        {
            player.canMove = false;
            player.canAttack = false;
            animator.SetBool("isAttacking2", true);
        }

        if(Input.GetButtonDown("Defend"))
        {
            animator.SetBool("isDefending", true);

            activeAura = Instantiate(defendAuraPrefab, gameObject.transform.position, defendAuraPrefab.transform.rotation);
            player.moveSpeed = 5f;
            player.isDefending = true;
        }
        else if(Input.GetButtonUp("Defend"))
        {
            animator.SetBool("isDefending", false);

            player.moveSpeed = 10f;
            player.isDefending = false;
            Destroy(activeAura);
        }

        if(activeAura)
        {
            activeAura.transform.position = gameObject.transform.position;
        }
    }

    public void ShootFireball()
    {
        projectile = Instantiate(fireballPrefab, projectileSpawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up) * 350);
        animator.SetBool("isAttacking2", false);
        player.canMove = true;
        player.canAttack = true;
    }
}
