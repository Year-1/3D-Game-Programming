using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UserInterface : MonoBehaviour
{
    public TextMeshProUGUI usernameDisplay;
    public TextMeshProUGUI ammoDisplay;

    public RectTransform healthBarDisplay;

    public GameObject scoreAnim;
    public RectTransform scoreDisplay;

    public GameObject scoreboard;
    public TextMeshProUGUI scoreboardScore;
    public TextMeshProUGUI scoreboardUser;
    public TextMeshProUGUI gold;

    public GameObject returnToMainMenu;

    CharacterInfo ci;

    int score;

    bool gameOver = false;

    public void Start()
    {
        ci = GameObject.FindGameObjectWithTag("CharInfo").GetComponent<CharacterInfo>();
        DisplayUsername();
    }

    //  Sets scoreboard to active when correct button is pressed.
    private void Update()
    {
        if (gameOver) {
            scoreboard.SetActive(true);
        } else if (Input.GetAxis("Menu") > 0)
        {
            scoreboard.SetActive(true);
            returnToMainMenu.SetActive(true);
            DisplayScoreboard();
        } else {
            scoreboard.SetActive(false);
            returnToMainMenu.SetActive(false);
        }
    }

    //  Displays the amount of ammo the player has.
    public void DisplayAmmo(int _shotCount)
    {
        ammoDisplay.text = _shotCount.ToString() + "/10";
    }

    //  Displays the player username at the bottom of the screen.
    void DisplayUsername()
    {
        usernameDisplay.text = "@" + ci.CharUsername;
    }

    //  Displayer the characters health at the bottom of the scren.
    public void DisplayHealth(int _health)
    {
        float normalisedHealth = (float)_health / 1000f;
        healthBarDisplay.localScale = new Vector3(normalisedHealth, 1, 1);
    }

    //  Instanitates the score object and gives it a value.
    public void DisplayScoreAnimation()
    {
        int scoreAmount = 100;
        score += scoreAmount;
        ScoreAnimation scoreA = scoreAnim.GetComponent<ScoreAnimation>();
        scoreA.Score(scoreAmount);
        Instantiate(scoreA, scoreDisplay);
    }

    //  Displays the scoreboard.
    public void DisplayScoreboard()
    {
        scoreboardScore.text = string.Format(String.Format("{0:D6}", score));
        scoreboardUser.text = ci.CharUsername;
    }

    //  Displays the players amount of gold.
    public void DisplayGold(int _gold)
    {
        gold.text = _gold.ToString();
    }

    //  Updates the scoreboard so the correct score is displayed at the end of the game.
    public void GameOver()
    {
        gameOver = true;
    }
}   
