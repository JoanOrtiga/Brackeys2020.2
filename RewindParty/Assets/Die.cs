using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    [SerializeField] private GameObject blood;
    private void OnDestroy()
    {
        Instantiate(blood, transform.position, transform.rotation);
    }
}
