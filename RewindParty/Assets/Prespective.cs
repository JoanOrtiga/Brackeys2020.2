using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prespective : MonoBehaviour
{
    [SerializeField] private int sortingBaseOrder = 5000;
    [SerializeField] private int offset = 0;

    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }
    private void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(sortingBaseOrder - transform.position.y - offset);
    }
}
