using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))][RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject blood;
    [SerializeField] private float movementSpeed = 5f;

    private Rigidbody2D rb;
    private Animator anim;

    private float inputX;
    private float inputY;
    private float xScale;

    private Transform light;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        light = transform.GetChild(0);
        xScale = transform.localScale.x;
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        MoveAnim(new Vector2(inputX, inputY));
    }

    private void FixedUpdate()
    {
        if (IsMoving)
        {
            Vector2 direction = Vector2.ClampMagnitude(new Vector2(inputX, inputY), 1f);
            rb.MovePosition(new Vector2(rb.position.x + direction.x * movementSpeed * Time.deltaTime, rb.position.y + direction.y * movementSpeed * Time.deltaTime));
        }
    }
    public bool IsMoving
    {
        get { return inputX != 0 || inputY != 0; }
    }

    private void OnDestroy()
    {
        Instantiate(blood, transform.position, transform.rotation);
        light.parent = null;
        light.GetComponent<AtenuateLight>().enabled = true;
    }

    private void MoveAnim(Vector2 dir)
    {
        if(dir.x > 0.5 || dir.x < -0.5)
        {
            anim.SetBool("HorizontalMove", true);

            if (dir.x < 0)
            {
                transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            anim.SetBool("HorizontalMove", false);
        }
    }
}
