using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
    private Vector2 lastPosition;
    private Vector2 currentPosition;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (((Vector2)transform.position == lastPosition))
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);

            Vector2 facingDir = ((Vector2)transform.position - lastPosition).normalized;

            animator.SetFloat("DirX", facingDir.x);
            animator.SetFloat("DirY", facingDir.y);
        }

        lastPosition = transform.position;
    }   
}
