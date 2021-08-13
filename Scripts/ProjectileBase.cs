using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player") && !other.CompareTag("Item"))
        {
            if(other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyBase>().ApplyDamage(damage);
            }

            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
