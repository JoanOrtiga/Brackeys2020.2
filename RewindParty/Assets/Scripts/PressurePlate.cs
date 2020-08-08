using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : EnergyActivators
{
    [SerializeField] private bool startActived = false;
    [Header("Who can activate it")]
    [SerializeField] private bool canPlayerActivate = true;
    [SerializeField] private bool canEnemyActivate = false;
    [SerializeField] private bool canBoxActivate = true;

    private void Start()
    {
        imActive = startActived;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;

        if(canPlayerActivate && tag == "Player" || (canEnemyActivate && tag == "Enemy" && Vector2.Distance(collision.transform.position, transform.position) < 0.3f) || canBoxActivate && tag == "MoveableBox")
        {
            imActive = true;
            AudioManager.AudioInstance.Play("Activate");
        }   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string tag = collision.tag;

        if (canPlayerActivate && tag == "Player" || (canEnemyActivate && tag == "Enemy" && Vector2.Distance(collision.transform.position, transform.position) < 0.3f) || canBoxActivate && tag == "MoveableBox")
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
