using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    /// <summary>
    ///     Gets a reference to all the sound object within the scene.
    /// </summary>
    public static Sounds sound;

    public AudioClip cannonShot;
    public AudioClip backgroundNoise;
    public AudioClip music;
    public AudioClip lightningBolt;

    private void Start()
    {
        if (sound == null) {
            DontDestroyOnLoad(gameObject);
            sound = this;
        } else if (sound != this) {
            Destroy(gameObject);
        }
    }
}
