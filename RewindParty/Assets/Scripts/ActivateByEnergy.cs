using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateByEnergy : MonoBehaviour
{
    [SerializeField] private EnergyActivators[] activators;

    private Collider2D collider2;
    private void Start()
    {
        collider2 = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (AllActive())
        {
            collider2.enabled = false;

            //Here we changesprite and disable collider.
        }
        else
        {
            collider2.enabled = true;
        }
    }


    private bool AllActive()
    {
        foreach (EnergyActivators item in activators)
        {
            if (!item.isActive())
                return false;
        }

        return true;
    }
}
