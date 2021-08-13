using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public enum projectileType
    {
        Explosion
    }

    public GameObject hitEffect;
    public int damage;

    private bool isBlasting = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player") && !other.CompareTag("Item"))
        {
            if(!isBlasting)
            {
                SphereCollider blast = gameObject.AddComponent<SphereCollider>();
                blast.radius = 10f;
                blast.isTrigger = true;
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                isBlasting = true;
            }

            if(other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyBase>().ApplyDamage(damage);
            }

            Destroy(gameObject, 0.1f);
        }
    }
}
