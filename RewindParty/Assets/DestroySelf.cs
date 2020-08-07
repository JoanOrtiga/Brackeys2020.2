using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] private float destroyTime = 1;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
}
