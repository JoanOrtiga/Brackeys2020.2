using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;

public class Clock : MonoBehaviour
{
    public bool pause;

    [SerializeField] private int startHour = 1, startMinutes = 1, startSeconds = 1;

    /// <summary>
    /// Speed at which time goes
    /// </summary>
    [SerializeField] private float timeSpeed = 1;

    private float timer;
    private Text textClock;

    void Awake()
    {
        textClock = GetComponent<Text>();

        timer += startHour * 3600;
        timer += startMinutes * 60;
        timer += startSeconds;
    }

    void Update()
    {
        if (!pause)
        {
            timer += Time.deltaTime * timeSpeed;

            if(Mathf.Floor((timer % 216000) / 3600).ToString("00") == "24")
            {
                timer = 0;
            }

            string hours = Mathf.Floor((timer % 216000) / 3600).ToString("00");
            string minutes = Mathf.Floor((timer % 3600) / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");

            textClock.text = hours + ":" + minutes + ":" + seconds;

            
        }
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }

}
