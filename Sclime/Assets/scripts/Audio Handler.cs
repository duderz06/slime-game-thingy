using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    //Static Variables for keeping track of how loud the player wants the sound effects and music
    public static float SFXVolume = 0.5f;
    public static float musicVolume = 0.5f;

    //Two different fields for the bgm & every other sound effect
    [SerializeField] public AudioSource SFXSource;
    [SerializeField] public AudioSource musicSource;

    //Audio Clip array so that we can store a whole bunch of audio clips
    public AudioClip[] SFXAudioClips;
    public AudioClip musicAudioClip;

    private void Awake()
    {
        //Set the volume of the AudioSources to the ones chosen previously
        SFXSource.volume = SFXVolume;
        musicSource.volume = musicVolume;


        //Play background music on startup *Save 0 element in the array for background music
        musicSource.clip = musicAudioClip;
        musicSource.Play();
        musicSource.loop = true;

        DontDestroyOnLoad(this.gameObject);
    }

    //PlaySound is a method to call to play sounds from other scripts
    //Just put "audioHandler.PlaySound(.SFXAudioClips[#], 1.0f, 1.0f);" in whatever script you need
    //And don't forget to GetComponent
    public void PlaySound(AudioClip clip, float rangeLow, float rangeHigh)
    {
        SFXSource.pitch = Random.Range(rangeLow, rangeHigh);
        SFXSource.PlayOneShot(clip);
    }

    // TO-DO: check functionality
    public void SetSFXVolume(float volume)
    {
        SFXVolume = volume;
        SFXSource.volume = volume;
    }
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        musicSource.volume = volume;
    }

    
}
