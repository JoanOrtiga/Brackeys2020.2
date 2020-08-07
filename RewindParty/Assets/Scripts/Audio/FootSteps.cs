using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    private float checkSpeed = -1;
    public float footsteptsSpeed;
    private PlayerMovement movement;
    private bool isColliding;
    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }
    private void FixedUpdate()
    {
        PlayFootStepts();
    }
    private void PlayFootStepts()
    {
        if (movement.IsMoving && !isColliding)
        {
            if (checkSpeed < 0)
            {
                AudioManager.AudioInstance.Play("Footstep");
                checkSpeed = footsteptsSpeed;
            }
            else
            {
                checkSpeed -= Time.deltaTime;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }
}
