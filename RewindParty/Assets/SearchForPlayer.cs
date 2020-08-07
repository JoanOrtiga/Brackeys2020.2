using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : MonoBehaviour
{
    private Pathfinding.AIPath aipath;
    private Pathfinding.Seeker seeker;
    private Pathfinding.AIDestinationSetter aidestination;

    bool searching;

    private void Start()
    {
        aipath = GetComponent<Pathfinding.AIPath>();
        seeker = GetComponent<Pathfinding.Seeker>();
        aidestination = GetComponent<Pathfinding.AIDestinationSetter>();
    }

    private void Update()
    {

        if (!searching)
        {
            aipath.enabled = false;
            seeker.enabled = false;
            aidestination.enabled = false;
        }
        else
        {
            aipath.enabled = true;
            seeker.enabled = true;
            aidestination.enabled = true;

            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            searching = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            searching = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            searching = false;
    }
}
