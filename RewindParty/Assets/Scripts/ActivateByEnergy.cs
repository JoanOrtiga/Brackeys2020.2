using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateByEnergy : MonoBehaviour
{
    [SerializeField] private EnergyActivators[] activators;

    [SerializeField] private bool AllEnemiesHaveToBeDead;
    [SerializeField] private bool UseEnergy = true;

    private Collider2D collider2;
    private bool shake = false;
    [SerializeField]
    private GameObject[] enemies;

    private void Start()
    {
        collider2 = GetComponent<BoxCollider2D>();
        if (AllEnemiesHaveToBeDead)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }


    }

    private void Update()
    {
        if (AllKilled() && AllEnemiesHaveToBeDead)
        {

            collider2.enabled = false;
            GetComponent<Animator>().SetBool("Opened", true);

            if (!shake)
            {
                shake = true;
                Camera.main.GetComponent<CameraShake>().Shake(0.5f, 0.015f);
                AudioManager.AudioInstance.Play("Door");
            }
        }

        if (UseEnergy)
        {
            if (AllActive())
            {
                collider2.enabled = false;
                GetComponent<Animator>().SetBool("Opened", true);

                if (!shake)
                {
                    shake = true;
                    Camera.main.GetComponent<CameraShake>().Shake(0.5f, 0.015f);
                    AudioManager.AudioInstance.Play("Door");
                }
                //Here we changesprite and disable collider.
            }
            else
            {
                collider2.enabled = true;
                GetComponent<Animator>().SetBool("Opened", false);
                if (shake)
                {
                    shake = false;
                    Camera.main.GetComponent<CameraShake>().Shake(0.4f, 0.012f);
                    AudioManager.AudioInstance.Play("Door");
                }
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

    private bool AllKilled()
    {
        foreach (GameObject item in enemies)
        {
            if (item != null)
            {
                return false;
            }
        }

        return true;
    }
}
