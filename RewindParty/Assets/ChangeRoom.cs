using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private Transform camPos;
    [SerializeField] private Transform playerPos;

    private GameObject player;

    private void Start()
    {
        cam = Camera.main;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.transform.position = new Vector3(camPos.position.x, camPos.position.y, cam.transform.position.z);
        player.transform.position = playerPos.position;
    }
}
