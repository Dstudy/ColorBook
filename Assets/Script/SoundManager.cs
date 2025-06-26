using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    public AudioSource backgroundAudioSource;
    // public AudioSource backgroundAudioSource;
    public AudioSource clickAudioSource;
    public AudioClip[] audioClips;
    public Slider musicSlider;
    public Slider soundSlider;
    public GameObject Settings;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(Settings);
    }

    public void PlaySound(int index)
    {
        clickAudioSource.clip = audioClips[index];
        clickAudioSource.Play();
    }
    
    public void PlayMusic()
    {
        backgroundAudioSource.Play();
    }

    private void Update()
    {
        if(musicSlider != null)
            backgroundAudioSource.volume = musicSlider.value;
        if(soundSlider != null)
            clickAudioSource.volume = soundSlider.value;
    }
}
