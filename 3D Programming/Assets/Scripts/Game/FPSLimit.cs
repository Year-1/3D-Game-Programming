using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    //  Limits the framerate of the game so my gpu doesnt cunt punch itself.
    public static FPSLimit framesPerSecond;
    private int frameRate;

    void Awake()
    {
        frameRate = 120;
        QualitySettings.vSyncCount = 0;
    }

    private void Start()
    {
        if (framesPerSecond == null) {
            DontDestroyOnLoad(gameObject);
            framesPerSecond = this;
        } else if (framesPerSecond != this) {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (frameRate != Application.targetFrameRate) {
            Application.targetFrameRate = frameRate;
        }
    }
}

