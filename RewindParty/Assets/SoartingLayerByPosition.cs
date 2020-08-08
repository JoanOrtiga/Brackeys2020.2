using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoartingLayerByPosition : MonoBehaviour
{
    private SpriteRenderer spr;
    public int offset = 0;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spr.sortingOrder = (int)((transform.position.y) * -10) + offset;
    }
}
