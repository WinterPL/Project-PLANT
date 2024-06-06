using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] Animator P_Animator;

    private Vector2 movement;
    private Rigidbody2D rb;
    private bool moving = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMovement(InputValue value)
    {
       movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement *speed* Time.fixedDeltaTime);

        moving = (movement.sqrMagnitude > 0);

        if (moving)
        {
            P_Animator.ResetTrigger("Idling");
            P_Animator.SetTrigger("Walking");
        }
        else
        {

            P_Animator.ResetTrigger("Walking");
            P_Animator.SetTrigger("Idling");
        }
    }

}
