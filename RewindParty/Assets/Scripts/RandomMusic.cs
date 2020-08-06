using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class RandomMusic : MonoBehaviour
{
    [SerializeField] private int musicNum;
    private AudioSource music;
    [SerializeField] private AudioClip[] clip;
    void Start()
    {
        music = GetComponent<AudioSource>();
        int i = Random.Range(0, musicNum);
        print(i);
        music.clip = clip[i];
        music.loop = true;
        music.Play();
    }
}
