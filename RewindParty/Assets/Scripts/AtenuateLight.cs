using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class AtenuateLight : MonoBehaviour
{
    private Light2D light;

    private void OnEnable()
    {
        light = GetComponent<Light2D>();
        light.enabled = true;
    }

    private void Update()
    {
        light.intensity -= Time.deltaTime;
    }
}
