using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Image uiButton;
    public Sprite mutedMusic;
    public Sprite playingMusic;
    
    public AudioSource audioSource;

    public int muted;
    public Slider sliderValue;
    
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        int savedVolumeMute = PlayerPrefs.GetInt("audioMuted" , 0);
        
        
        if (savedVolumeMute == 1)
        {
            muted = 1;
            uiButton.sprite = mutedMusic;
            audioSource.Pause();

        }
        else
        {
            muted = 0;
            uiButton.sprite = playingMusic;
            audioSource.Play();
        }
        PlayerPrefs.SetInt("audioMuted",savedVolumeMute);
        
    }

    public void AudioSwitch()
    {
        if (muted == 0)
        {
            muted = 1;
            uiButton.sprite = mutedMusic;
            audioSource.Pause();

        }
        else
        {
            muted = 0;
            uiButton.sprite = playingMusic;
            audioSource.Play();
        }
        PlayerPrefs.SetInt("audioMuted",muted);
    }

    public void AudioLevel(float value)
    {
        PlayerPrefs.SetFloat("audioLevel",value);

        audioSource.volume = value;
        
    }
}
