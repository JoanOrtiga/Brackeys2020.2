using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    private BackTrackingBox boxMovementScript;

    [SerializeField] [Range(0f, 1f)] private float movementSpeedLerpValue;

    private Collision2DSideType collisionSide;

    [HideInInspector] public bool gettingMoved;

    [SerializeField] private float timeBoxMovement = 0.4f;
    private float countdownBoxMovement;

    private Vector2 beforeMovingPos;
    private Vector2 movingToPos;
    private CameraShake main;

    private Rigidbody2D rb;

    private void Start()
    {
        main = Camera.main.GetComponent<CameraShake>();
        rb = GetComponent<Rigidbody2D>();

        boxMovementScript = GetComponent<BackTrackingBox>();

        countdownBoxMovement = timeBoxMovement;
        transform.position = BackTrackGrid.GetNearestPointOnGrid(transform.position);
    }

    void Update()
    {
        if (!boxMovementScript.isBackTracking())
        {
            if (gettingMoved)
            {
                MoveBoxForward();
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, transform.position, movementSpeedLerpValue);
            }

        }
    }

    private void LateUpdate()
    {
        rb.velocity = new Vector2(0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            countdownBoxMovement = timeBoxMovement;

            Vector2 pointOfContact = collision.contacts[0].normal;
            collisionSide = GetCollisionSide(pointOfContact);

            if (boxMovementScript.isBackTracking())
            {
                Destroy(collision.gameObject);
                main.Shake(0.075f, 0.05f);
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            gettingMoved = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (boxMovementScript.isBackTracking())
            {
                Destroy(collision.gameObject);
                main.Shake(0.075f, 0.05f);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            countdownBoxMovement -= Time.deltaTime;

            Vector2 pointOfContact = collision.contacts[0].normal;

            if (collisionSide != GetCollisionSide(pointOfContact))
            {
                countdownBoxMovement = timeBoxMovement;
            }

            if (countdownBoxMovement <= 0)
            {
                beforeMovingPos = BackTrackGrid.GetNearestPointOnGrid(transform.position);
                movingToPos = movingTo();

                Collider2D[] checkWall;

                checkWall = Physics2D.OverlapBoxAll(movingToPos, new Vector2(0.95f, 0.95f), 0);

                foreach (var item in checkWall)
                {
                    if (item.tag == "Wall")
                    {
                        countdownBoxMovement = timeBoxMovement;

                        return;
                    }
                }

                gettingMoved = true;
                main.Shake(0.075f, 0.01f);
                AudioManager.AudioInstance.Play("PushBox");
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            gettingMoved = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            countdownBoxMovement = timeBoxMovement;
        }
    }

    private Vector2 movingTo()
    {
        switch (collisionSide)
        {
            case Collision2DSideType.None:
                print("Error Side Collider");
                break;
            case Collision2DSideType.Left:
                return beforeMovingPos + Vector2.right;

            case Collision2DSideType.Right:
                return beforeMovingPos + Vector2.left;

            case Collision2DSideType.Top:
                return beforeMovingPos + Vector2.down;

            case Collision2DSideType.Bottom:
                return beforeMovingPos + Vector2.up;

        }

        print("error moving To");
        return Vector2.zero;
    }

    private void MoveBoxForward()
    {
        transform.position = Vector2.Lerp(transform.position, movingToPos, timeBoxMovement);

        if (Vector2.Distance(transform.position, movingToPos) < 0.01f)
        {
            gettingMoved = false;
        }
    }



    private Collision2DSideType GetCollisionSide(Vector2 pointOfContact)
    {
        if (pointOfContact == new Vector2(1, 0))
        {
            return Collision2DSideType.Left;
        }

        if (pointOfContact == new Vector2(-1, 0))
        {
            return Collision2DSideType.Right;
        }

        if (pointOfContact == new Vector2(0, 1))
        {
            return Collision2DSideType.Bottom;
        }

        if (pointOfContact == new Vector2(0, -1))
        {
            return Collision2DSideType.Top;
        }

        print("SideError");
        return Collision2DSideType.None;
    }
}
