using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] Animator p_Animator;

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
            p_Animator.ResetTrigger("Idling");
            p_Animator.SetTrigger("Walking");
        }
        else
        {

            p_Animator.ResetTrigger("Walking");
            p_Animator.SetTrigger("Idling");
        }
    }

}
