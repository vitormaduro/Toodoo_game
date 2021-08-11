using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;

    public bool isInventoryOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInventoryOpen) return;

        if(Input.GetButtonDown("Fire2"))
        {
            animator.SetBool("isAttacking2", true);
        } 
        else if(Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("isAttacking2", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isAttacking1", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("isAttacking1", false);
        }
    }
}
