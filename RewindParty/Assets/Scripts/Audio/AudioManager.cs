using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)] public float volume;
    [Range(0f, 3f)] public float pitch;

    [HideInInspector]public AudioSource source;
    [HideInInspector] public float startVolume;
}
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private AudioSource music;
    [SerializeField] private AudioClip[] musicClips;
    [Range(0f, 1f)][SerializeField] private float MusicVolume;
    public static AudioManager AudioInstance;
    void Awake()
    {
        if (AudioInstance == null)
        {
            AudioInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.startVolume = s.volume;
            s.source.pitch = s.pitch;
        }
        MusicSetUp();
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (name == "Footstep")
        {
            s.source.pitch = UnityEngine.Random.Range(s.pitch - 0.2f, s.pitch + 0.2f);
        }
        s.source.Play();
    }
    public void SetVolumeSFX(float value)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.startVolume * value;
        }
    }
    public void SetVolumeMusic(float value)
    {
        music.volume = MusicVolume * value;
    }
    private void MusicSetUp()
    {
        music = GetComponent<AudioSource>();
        int i = UnityEngine.Random.Range(0, musicClips.Length);
        music.volume = MusicVolume;
        music.clip = musicClips[i];
        music.loop = true;
        music.Play();
    }
}
