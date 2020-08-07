using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float cooldown;
    private Vector3 initialPos;
    private void Start()
    {
        initialPos = transform.position;
    }
    //Per fer la funció: Camera.main.GetComponent<CameraShake>().Shake();
    public void Shake(float duration, float force)
    {
        StartCoroutine(StartShaking(duration, force));
    }
    private IEnumerator StartShaking(float duration, float force)
    {
        cooldown = duration;

        while (cooldown > 0)
        {
            float xShakePos = initialPos.x + Random.Range(-1f, 1f) * force;
            float yShakePos = initialPos.y + Random.Range(-1f, 1f) * force;

            transform.position = new Vector3(xShakePos, yShakePos, initialPos.z);
            cooldown -= Time.deltaTime;
            yield return null;
        }
        transform.position = initialPos;
    }
}
