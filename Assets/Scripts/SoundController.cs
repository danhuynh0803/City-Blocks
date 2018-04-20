using System.Collections;
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
    [Header("SFX audio clips")]
    public AudioClip[] sfxClips;                
    public static AudioSource[] sources;

    [Header("Volume Controls")]
    public static float masterVolume;
    public static float bgmVolume;
    public static float sfxVolume;

    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;

    static bool isAudioOn = false;
    AudioSource bgmAudio;

    // To keep BGM persistent when changing levels
    void Awake()
    {
        // set up bgm audio 
        bgmAudio = GetComponent<AudioSource>();

        // Set up sfx audio
        sources = new AudioSource[sfxClips.Length];
        for (int i = 0; i < sfxClips.Length; ++i)
        {
            GameObject child = new GameObject("Player");
            child.transform.parent = gameObject.transform;
            sources[i] = child.AddComponent<AudioSource>() as AudioSource;
            sources[i].clip = sfxClips[i];
        }

        // Play BGM audio if it's not currently being played
        if (!isAudioOn)
        {
            bgmAudio.Play();
            DontDestroyOnLoad(this.gameObject);
            isAudioOn = true;
        }
        // If BGM audio is being played then don't play any new BGM audio clips
        // otherwise, we'd get multiple BGMs playing at once
        else
        {
            bgmAudio.Stop();
        }
    }

    void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(delegate { OnMasterVolumeValueChanged(); });
        bgmVolumeSlider.onValueChanged.AddListener(delegate { OnBGMVolumeValueChanged(); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { OnSFXVolumeValueChanged(); });
    }

    void Update()
    {
        masterVolume = masterVolumeSlider.value;
        bgmVolume = bgmVolumeSlider.value;
        sfxVolume = sfxVolumeSlider.value;

        // Update bgm volume
        bgmAudio.volume = Mathf.Min(bgmVolume, masterVolume);
    }

    public static void Play(int soundIndex)
    {
        sources[soundIndex].volume = Mathf.Min(sfxVolume, masterVolume);  // Play at specified volume
        sources[soundIndex].Play();
    }

    // Use this version to manually modify the volume level
    // For example, if we want to change the volume priority of different events
    public static void Play(int soundIndex, float volumeLevel)  
    {
        volumeLevel = Mathf.Clamp(volumeLevel, 0.0f, 1.0f);
        sources[soundIndex].volume = volumeLevel * Mathf.Min(sfxVolume, masterVolume);
        sources[soundIndex].Play();
    }

    public static void PlayWithoutInterruption(int soundIndex)
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
