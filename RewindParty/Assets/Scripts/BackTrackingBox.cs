using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class BackTrackingBox : MonoBehaviour
{
    private List<Vector2> trackPositions;
    private Vector2 lastTrackPos;

    private bool goingBackAnim = false;
    private Vector2 goingBackPos;
    [SerializeField][Range(0f,1f)] private float lerpValue = 0.1f;
    private int posIndex;

    private float time;
    [SerializeField] private float timeBetweenAnim = 0.2f;

    //--------------------

    [SerializeField] private float timeToMove = 1f;
    private bool gettingMoved = false;
    private float movingTime = 0;

    Collision2DSideType collisionSide;
    private Vector2 beforeMovingPos;
    private Vector2 movingToPos;

    private void Awake()
    {
        trackPositions = new List<Vector2>();

        time = timeBetweenAnim;
        goingBackAnim = false;

        GetComponent<GhostTrail>().enabled = false;
    }

    public bool isBackTracking()
    {
        return goingBackAnim;
    }

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Timer").GetComponent<CountDownTimer>().timeAt0.AddListener(ResetPos);
    }

    private void Update()
    {
        if (!goingBackAnim)
        {
            if (gettingMoved)
                MoveBoxForward();
            else
                transform.position = Vector2.Lerp(transform.position, BackTrackGrid.GetNearestPointOnGrid(transform.position), lerpValue);

            Vector2 newPos = BackTrackGrid.GetNearestPointOnGrid(transform.position);

            print(newPos);

            if (lastTrackPos != newPos)
            {
                trackPositions.Add(newPos);
                lastTrackPos = newPos;
                goingBackPos = newPos;
            }

            
        }
        else
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = timeBetweenAnim;

                posIndex--;

                if(posIndex < 0)
                {
                    trackPositions.Clear();

                    goingBackAnim = false;
                    GetComponent<GhostTrail>().enabled = false;

                    return;
                }

                goingBackPos = trackPositions[posIndex];
            }

            transform.position = Vector2.Lerp(transform.position, goingBackPos, time / timeBetweenAnim);
        }
    }

    private void ResetPos()
    { 
        posIndex = trackPositions.Count - 1;

        if(posIndex <= 0)
        {
            goingBackAnim = false;
        }
        else
        {
            goingBackAnim = true;
            GetComponent<GhostTrail>().enabled = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            movingTime -= Time.deltaTime;

            if(movingTime <= 0)
            {
                collisionSide = collision.GetContactSide();
                beforeMovingPos = BackTrackGrid.GetNearestPointOnGrid(transform.position);
                movingToPos = movingTo();

                gettingMoved = true;
                MoveBoxForward();
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            //movingToPos = beforeMovingPos;

            gettingMoved = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            movingTime = timeToMove;

            if (goingBackAnim)
            {
                Destroy(collision.gameObject);
            }
        }



        if (collision.gameObject.CompareTag("Wall"))
        {
            //movingToPos = beforeMovingPos;

            gettingMoved = false;
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
        transform.position = Vector2.Lerp(transform.position, movingToPos, lerpValue);

        if(Vector2.Distance(transform.position, movingToPos) < 0.01f)
        {
            gettingMoved = false;
        } 
    }
}
