using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    public Slider ocean, music, sfx;

    public void Start()
    {
        if (PlayerPrefs.GetInt("Once") == 1) {
            PlayerPrefs.SetFloat("Ocean", 1);
            PlayerPrefs.SetFloat("Music", 1);
            PlayerPrefs.SetFloat("Sfx", 1);
            PlayerPrefs.SetInt("Once", 1);
        }
    }

    /// <summary>
    ///     Loads the players values from the player prefs.
    /// </summary>
    public void Load()
    {
        float oceanVal = PlayerPrefs.GetFloat("Ocean");
        float musicVal = PlayerPrefs.GetFloat("Music");
        float sfxVal = PlayerPrefs.GetFloat("Sfx");

        ocean.value = oceanVal;
        music.value = musicVal;
        sfx.value = sfxVal;
    }

    /// <summary>
    ///     Saves the players values to player prefs.
    /// </summary>
    public void Save()
    {
        PlayerPrefs.SetFloat("Ocean", ocean.value);
        PlayerPrefs.SetFloat("Music", music.value);
        PlayerPrefs.SetFloat("Sfx", sfx.value);
    }
}
