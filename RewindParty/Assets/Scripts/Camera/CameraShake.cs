using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float force;
    public float duration;
    private float cooldown;
    private void Start()
    {
        cooldown = duration;
    }
    //Per fer la funció: Camera.main.GetComponent<CameraShake>().Shake();
    public void Shake()
    {
        StartCoroutine(StartShaking());
    }
    private IEnumerator StartShaking()
    {
        Vector3 initialPos = transform.localPosition;
        cooldown = duration;

        while (cooldown > 0)
        {
            float xShakePos = initialPos.x + Random.Range(-1f, 1f) * force;
            float yShakePos = initialPos.y + Random.Range(-1f, 1f) * force;

            transform.localPosition = new Vector3(xShakePos, yShakePos, initialPos.z);
            cooldown -= Time.deltaTime;
            yield return null;
        }
        transform.localPosition = initialPos; //avoid bugs, camera can end placed in local position wich is not the one we want so we assign the initial one.
    }
}
