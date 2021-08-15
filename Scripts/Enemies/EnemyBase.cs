using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float health;
    public bool isAlert;
    public bool canAttack;
    public bool hasWon = false;

    private GameController gc;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        animator = GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            gc.MarkEnemyKill(gameObject);
            Destroy(gameObject);
        }
    }

    public void SetHasWon()
    {
        animator.SetBool("hasWon", true);
        animator.SetBool("isAlert", false);
        animator.SetBool("isAttacking", false);
        isAlert = false;
        canAttack = false;
        hasWon = true;
    }
}
