using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private GameObject check;
    public void OnClick()
    {
        if (check.activeSelf)
        {
            check.SetActive(false);
        }
        else
        {
            check.SetActive(true);
        }
    }
}
