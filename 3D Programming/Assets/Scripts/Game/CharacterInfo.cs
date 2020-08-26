using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public static CharacterInfo charInfo;

    private string charUsername;
    bool loggedIn;
    int score;

    //  Used for getting the characters details.
    public string CharUsername { get{ return charUsername;} set {charUsername = value;} }
    public bool LoggedIn { get{ return loggedIn;} set {loggedIn = value;} }
    public int Score { get{ return score;} set {score += value;} }

    private void Start()
    {
        if (charInfo == null)
        {
            DontDestroyOnLoad(gameObject);
            charInfo = this;
        }
        else if (charInfo != this)
        {
            Destroy(gameObject);
        }
    }
}
