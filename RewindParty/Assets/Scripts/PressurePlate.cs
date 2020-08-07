using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : EnergyActivators
{
    [Header("Who can activate it")]
    [SerializeField] private bool canPlayerActivate = true;
    [SerializeField] private bool canEnemyActivate = false;
    [SerializeField] private bool canBoxActivate = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;

        if(canPlayerActivate && tag == "Player" || canEnemyActivate && tag == "Enemy" || canBoxActivate && tag == "MoveableBox")
        {
            imActive = true;
            AudioManager.AudioInstance.Play("Activate");
        }   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string tag = collision.tag;

        if (canPlayerActivate && tag == "Player" || canEnemyActivate && tag == "Enemy" || canBoxActivate && tag == "MoveableBox")
        {
            imActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string tag = collision.tag;

        if (canPlayerActivate && tag == "Player" || canEnemyActivate && tag == "Enemy" || canBoxActivate && tag == "MoveableBox")
        {
            imActive = false;
        }
    }
}
