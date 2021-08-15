using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int health = 10;
    public bool canMove = true;
    public bool isDefending = false;
    public bool canAttack = true;
    public float moveSpeed = 10f;

    private Animator animator;
    private GameController gc;
    private float iFrames;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        iFrames += Time.deltaTime;
    }

    public void ApplyDamage(int damage)
    {
        if (health <= 0) return;
        if (iFrames < 1) return;
        if (isDefending) return;

        SetHitFx(1);
        iFrames = 0;

        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking2", false);
            canMove = false;
            canAttack = false;

            StartCoroutine(gc.FinishGame(false));
        }
    }

    public void SetHitFx(int type)
    {
        animator.SetBool("isGettingHit", (type == 1));
    }
}
