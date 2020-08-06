﻿using System;
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
}
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
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
            s.source.pitch = s.pitch;
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
