﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SFX
{
    /*
    RockBreakLarge,
    RockBreakMedium,
    RockBreakSmall
    */
}


public class SoundController : MonoBehaviour {

    // Make sure clips are ordered in the same as the enum
    public AudioClip[] clips;                
    public static AudioSource[] sources;
    public static float masterVolume;
    public static float bgmVolume;
    public static float sfxVolume;

    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;

    void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(delegate { OnMasterVolumeValueChanged(); });
        bgmVolumeSlider.onValueChanged.AddListener(delegate { OnBGMVolumeValueChanged(); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { OnSFXVolumeValueChanged(); });

        // Set up sfx audio
        sources = new AudioSource[clips.Length];
        for (int i = 0; i < clips.Length; ++i)
        {
            GameObject child = new GameObject("Player");
            child.transform.parent = gameObject.transform;
            sources[i] = child.AddComponent<AudioSource>() as AudioSource;
            sources[i].clip = clips[i];
        }
    }
    void Update()
    {
        masterVolume = masterVolumeSlider.value;
        bgmVolume = bgmVolumeSlider.value;
        sfxVolume = sfxVolumeSlider.value;
    }
    public static void Play(int soundIndex)
    {
        sources[soundIndex].volume = Mathf.Min(sfxVolume, masterVolume);  // Play at specified volume
        sources[soundIndex].Play();
    }
    public static void Play(int soundIndex, float volumeLevel)
    {
        volumeLevel = Mathf.Clamp(volumeLevel, 0.0f, 1.0f);
        sources[soundIndex].volume = volumeLevel * Mathf.Min(sfxVolume, masterVolume);
        sources[soundIndex].Play();
    }
    public static void PlayWithOutInterrpution(int soundIndex)
    {
        AudioSource clip = sources[soundIndex];
        if (!clip.isPlaying)
        {
            clip.volume = Mathf.Min(sfxVolume, masterVolume);
            clip.Play();
        }
    }
    // Refactor to use these functions without using attached sliders maybe?
    public void OnMasterVolumeValueChanged()
    {
        masterVolume = masterVolumeSlider.value;
    }
    public void OnBGMVolumeValueChanged()
    {
        bgmVolume = bgmVolumeSlider.value;
    }
    public void OnSFXVolumeValueChanged()
    {
        sfxVolume = sfxVolumeSlider.value;
    }
}
