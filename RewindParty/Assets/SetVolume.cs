using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private Slider sfxVolume;
    [SerializeField] private Slider musicVolume;
    public void SetSFXVolume()
    {
        AudioManager.AudioInstance.SetVolumeSFX(sfxVolume.value);
    }
    public void SetMusicVolume()
    {
        AudioManager.AudioInstance.SetVolumeMusic(musicVolume.value);
    }
}
