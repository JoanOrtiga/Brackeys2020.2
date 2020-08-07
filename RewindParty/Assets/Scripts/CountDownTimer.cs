using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private float countDownTime;
    public UnityEvent timeAt0;

    private float currentTime;
    private Text text;

    public bool countingDown = true;

    private void Start()
    {
        currentTime = countDownTime;
        text = GetComponent<Text>();

        countingDown = true;
    }

    private void Update()
    {
        if (countingDown)
        {
            currentTime -= Time.deltaTime;

            if (currentTime < 10)
            {
                text.text = currentTime.ToString("F2");
            }
            else
            {
                text.text = Mathf.RoundToInt(currentTime).ToString();
            }

            if (currentTime < 0)
            {
                timeAt0.Invoke();
                text.text = "0,00";
                currentTime = countDownTime;

                countingDown = false;
            }
        } 
    }
}
