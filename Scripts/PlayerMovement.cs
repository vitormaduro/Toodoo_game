using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    Vector3 playerVelocity;
    float vSpeed;
    GameController gc;

    public float playerSpeed = 20.0f;
    public float jumpSpeed = 0.2f;
    public float gravitySpeed = 1f;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        float horizontal = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        Vector3 movement = transform.right * horizontal + transform.forward * vertical;
        if(controller.isGrounded)
        {
            vSpeed = 0f;
            if(Input.GetButtonDown("Jump"))
            {
                vSpeed = jumpSpeed;
            }
        }

        vSpeed -= gravitySpeed * Time.deltaTime;

        movement.y = vSpeed;
        controller.Move(movement);

        if(movement.x != 0f || movement.z != 0f) {
            animator.SetBool("isMoving", true);
        } else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.CompareTag("MovObj"))
        {
            Rigidbody rb = hit.collider.attachedRigidbody;

            if(rb && !rb.isKinematic)
            {
                rb.AddForce(hit.moveDirection * 5);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            canMove = false;
            animator.SetBool("hasWon", true);
            gc.FinishGame();
        }
    }
}
