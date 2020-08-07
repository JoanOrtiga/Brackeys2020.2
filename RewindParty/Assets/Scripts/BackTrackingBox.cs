using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTrackingBox : MonoBehaviour
{
    private List<Vector2> trackPositions;
    private Vector2 lastTrackPos;

    private bool goingBackAnim = false;
    private Vector2 goingBackPos;
    private int posIndex;

    private float time;
    [SerializeField] private float timeBetweenAnim = 0.2f;

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
            Vector2 newPos = BackTrackGrid.GetNearestPointOnGrid(transform.position);

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
}
