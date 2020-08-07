using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateByEnergy : MonoBehaviour
{
    [SerializeField] private EnergyActivators[] activators;

    private Collider2D collider2;
    private bool shake = false;
    private void Start()
    {
        collider2 = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (AllActive())
        {
            collider2.enabled = false;
            GetComponent<Animator>().SetBool("Opened", true);

            if (!shake)
            {
                shake = true;
                Camera.main.GetComponent<CameraShake>().Shake(0.5f, 0.015f);
            }
            //Here we changesprite and disable collider.
        }            
        else
        {
            collider2.enabled = true;
            GetComponent<Animator>().SetBool("Opened", false);
            if(shake)
            {
                shake = false;
                Camera.main.GetComponent<CameraShake>().Shake(0.4f, 0.012f);
            }
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
