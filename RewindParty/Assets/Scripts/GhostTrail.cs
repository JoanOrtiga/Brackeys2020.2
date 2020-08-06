using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrail : MonoBehaviour
{
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private float delay = 1.0f;
    private float delta = 0;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private float destroyTime = 0.1f;
    [SerializeField] private Color color;
    [SerializeField] private Material material = null;
    void Update()
    {
        if (delta > 0)
        {
            delta -= Time.deltaTime;
        }
        else
        {
            delta = delay;
            CreateGhostTrail();
        }
    }
    private void CreateGhostTrail()
    {
        GameObject ghostObj = Instantiate(ghostPrefab, transform.position, transform.rotation);
        ghostObj.transform.localScale = gameObject.transform.localScale;
        Destroy(ghostObj, destroyTime);

        spriteRenderer = ghostObj.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        spriteRenderer.color = color;
        if (material)
        {
            spriteRenderer.material = material;
        }
    }
}
