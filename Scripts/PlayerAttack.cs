using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    GameObject fireballPrefab;
    GameObject projectile;
    GameObject defendAuraPrefab;
    GameObject activeAura;
    Transform projectileSpawnPoint;

    public bool isInventoryOpen = false;
    public bool hasMagic = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        fireballPrefab = Resources.Load<GameObject>("Fireball");
        projectileSpawnPoint = transform.Find("ProjectileSpawn");
        defendAuraPrefab = Resources.Load<GameObject>("DefendAura");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInventoryOpen) return;
        if (!hasMagic) return;

        if(Input.GetButtonDown("Fire2"))
        {
            animator.SetBool("isAttacking2", true);

            projectile = Instantiate(fireballPrefab, projectileSpawnPoint.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up) * 350);
        } 
        else if(Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("isAttacking2", false);
        }

        if(Input.GetButtonDown("Defend"))
        {
            animator.SetBool("isDefending", true);

            activeAura = Instantiate(defendAuraPrefab, gameObject.transform.position, defendAuraPrefab.transform.rotation);
        }
        else if(Input.GetButtonUp("Defend"))
        {
            animator.SetBool("isDefending", false);

            Destroy(activeAura);
        }

        if(activeAura)
        {
            activeAura.transform.position = gameObject.transform.position;
        }
    }
}
