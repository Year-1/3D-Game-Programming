using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundsManager
{
    /// <summary>
    ///     Creates a new gameobject, adds an audio source, adjusts the sound volume to the player prefs.
    ///     plays the sound it gets from the sound class.
    /// </summary>
    public static void PlayerSound()
    {
        GameObject soundGO = new GameObject("CannonSound");
        AudioSource audioSource = soundGO.AddComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("Sfx");
        audioSource.PlayOneShot(Sounds.sound.cannonShot);
    }

    /// <summary>
    ///     Creates a new gameobject, adds an audio source, adjusts the sound volume to the player prefs.
    ///     plays the sound it gets from the sound class.
    /// </summary>
    public static void BackgroundNoise()
    {
        GameObject soundGO = new GameObject("OceanSound");
        AudioSource audioSource = soundGO.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = Sounds.sound.backgroundNoise;
        audioSource.volume = PlayerPrefs.GetFloat("Ocean");
        audioSource.Play();
    }

    /// <summary>
    ///     Creates a new gameobject, adds an audio source, adjusts the sound volume to the player prefs.
    ///     plays the sound it gets from the sound class.
    /// </summary>
    public static void Music()
    {
        GameObject soundGO = new GameObject("Music");
        AudioSource audioSource = soundGO.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = Sounds.sound.music;
        audioSource.volume = PlayerPrefs.GetFloat("Music");
        audioSource.Play();
    }

    
}
