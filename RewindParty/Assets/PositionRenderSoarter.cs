using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRenderSoarter : MonoBehaviour
{
    private int soartingOrderBase;
    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        //myRenderer.sortingOrder
    }
}
