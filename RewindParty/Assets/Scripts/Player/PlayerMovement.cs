using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))][RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    private Rigidbody2D rb;

    private float inputX;
    private float inputY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (isMoving())
        {
            Vector2 direction = Vector2.ClampMagnitude(new Vector2(inputX, inputY), 1f);

            rb.MovePosition(new Vector2(rb.position.x + direction.x * movementSpeed * Time.deltaTime, rb.position.y + direction.y * movementSpeed * Time.deltaTime));
        }
    }
    public bool isMoving()
    {
        return inputX != 0 || inputY != 0;
    }
}
