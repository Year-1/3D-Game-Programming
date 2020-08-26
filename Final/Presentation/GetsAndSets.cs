using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetsAndSets : MonoBehaviour
{
    private string charUsername;
    public string CharUsername {
        get { return charUsername; }
        set { charUsername = value; }
    }

    private bool loggedIn;
    public bool LoggedIn { 
        get { return loggedIn; }
        set { loggedIn = value; }
    }

    private int score;
    public int Score {
        get { return score; }
        set { score += value; }
    }

    private float waveHeight = 2.0f;
    public float WaveHeight {
        get { return waveHeight; }
        set { waveHeight = value; }
    }
}
