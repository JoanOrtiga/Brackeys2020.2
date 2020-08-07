using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private Slider sfxVolume;
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Dropdown resDropdown;
    private bool fullScreen = true;
    Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }
        options.Add(" ");
        resDropdown.AddOptions(options);
        resDropdown.value = currentResolution;
        resDropdown.RefreshShownValue();
    }
    public void SetSFXVolume()
    {
        AudioManager.AudioInstance.SetVolumeSFX(sfxVolume.value);
    }
    public void SetMusicVolume()
    {
        AudioManager.AudioInstance.SetVolumeMusic(musicVolume.value);
    }
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    public void FullScreen ()
    {
        fullScreen = !fullScreen;
        Screen.fullScreen = fullScreen;
    }
    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
