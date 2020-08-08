using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoartingLayerByPosition : MonoBehaviour
{
    private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spr.sortingOrder = (int)((transform.position.y) * -10);
    }
}
