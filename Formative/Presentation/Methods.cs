using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Methods : MonoBehaviour
{
    //  Displays the players health on screen.
    public void DisplayHealth(int health)
    {
        float normalisedHealth = (float)health / 1000f;
        healthBarDisplay.localScale = new Vector3(normalisedHealth, 1, 1);
    }

    //  Plays an animtion for when the player gains score.
    public void DisplayScoreAnimation()
    {
        ScoreAnimation score = scoreAnim.GetComponent<ScoreAnimation>();
        score.Score(100);
        Instantiate(score, scoreDisplay);
    }

    //  Registers and account to a database.
    IEnumerator Register()
    {
        failedAttemptText.SetActive(false);
        string url = "http://3dprogramming1.000webhostapp.com/php/register.php";
        //string url = "http://localhost/php/register.php";
        WWWForm form = new WWWForm();
        form.AddField("name", usernameInput.text);
        form.AddField("password", passwordInput.text);
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.downloadHandler.text == "0") {
            Debug.Log("User created succesfully!");
            otherPanel.SetActive(true);
            thisPanel.SetActive(false);
        } else {
            Debug.Log("User was not created" + www.downloadHandler.text);
            failedAttemptText.SetActive(true);
        }
    }

    //  Sets panels visibilty when password help is clicked.
    public void OpenPasswordHelp()
    {
        passwordHelpPanel.SetActive(true);
        passwordHelpButton.SetActive(false);
        usernameHelpButton.SetActive(false);
        usernameHelpPanel.SetActive(false);
    }

}
