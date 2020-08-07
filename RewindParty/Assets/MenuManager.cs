using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private MenuPanel pause;
    [SerializeField] private MenuPanel options;
    state currentState = state.Play;
    enum state
    {
        Paused,
        Option,
        Play
    }

    private void Start()
    {
        HideAll();
    }

    public void Show(string menu)
    {
        HideAll();
        switch (menu)
        {
            case "Options":
                options.Show();
                currentState = state.Option;
                break;
            case "Pause":
                pause.Show();
                break;
            default:
                HideAll();
                Time.timeScale = 1f;
                currentState = state.Play;
                break;
        }
    }
    private void HideAll()
    {
        pause.Hide();
        options.Hide();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == state.Paused)
            {
                HideAll();
                Time.timeScale = 1f;
                currentState = state.Play;
            }
            else if (currentState == state.Play || currentState == state.Option)
            {
                Show("Pause");
                Time.timeScale = 0f;
                currentState = state.Paused;
            }
        }
    }
}
