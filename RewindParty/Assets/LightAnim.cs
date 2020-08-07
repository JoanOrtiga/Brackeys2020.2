using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightAnim : MonoBehaviour
{
    Light2D lit;
    float defaultIntensity;

    float objective = 0;
    // Start is called before the first frame update
    void Start()
    {

        //  Random.state = System.DateTime.Now.Millisecond;
        lit = GetComponent<Light2D>();
        defaultIntensity = lit.intensity;

        InvokeRepeating("ChangeLight", 0.05f, 0.05f);
    }

    private void ChangeLight()
    {
        if (objective == 0 || lit.intensity == objective)
        {
            objective = Random.Range(-0.4f + defaultIntensity, 0.4f + defaultIntensity);
            objective = Mathf.Ceil(objective * 100) / 100;
        }
        else
        {       //0.61                //0.6
            if (lit.intensity < objective)
            {
                lit.intensity += 0.01f;
                lit.intensity = Mathf.Ceil(lit.intensity * 100) / 100;
            }
            else
            {
                lit.intensity -= 0.01f;
                lit.intensity = Mathf.Floor(lit.intensity * 100) / 100;
            }
        }
    }
}
