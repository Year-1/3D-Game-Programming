using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetsAndSets : MonoBehaviour
{
    //  These are 4 ways gets and sets were used during the games creation.
    //  3/4

    public string CharUsername { get { return charUsername; } set { charUsername = value; } }
    public bool LoggedIn { get { return loggedIn; } set { loggedIn = value; } }
    public int Score { get { return score; } set { score += value; } }
}
