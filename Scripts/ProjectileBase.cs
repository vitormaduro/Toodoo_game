using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public enum ProjectileType
    {
        Explosion,
        Line
    }

    public GameObject hitEffect;
    public ProjectileType projType;
    public int damage;

    private bool isBlasting = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Item"))
        {
            if ((projType == ProjectileType.Explosion && !isBlasting) || projType == ProjectileType.Line)
                Instantiate(hitEffect, transform.position, Quaternion.identity);

            if (projType == ProjectileType.Explosion && !isBlasting)
            {
                SphereCollider blast = gameObject.AddComponent<SphereCollider>();
                blast.radius = 10f;
                blast.isTrigger = true;
                isBlasting = true;
            }

            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyBase>().ApplyDamage(damage);
            } else if(other.CompareTag("Player"))
            {
                other.GetComponent<PlayerBase>().ApplyDamage(damage);
            }

            if(projType != ProjectileType.Line)    Destroy(gameObject, 0.1f);
        }
    }
}
