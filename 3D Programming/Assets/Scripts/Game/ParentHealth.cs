using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentHealth : MonoBehaviour
{

    public struct Health
    {
        public int health;
    }
    public UserInterface ui;
    public string cannonballID;

    public Health healthStruct;

    public GameObject treasure;

    public GameObject scoreBoard,
        returnToMainMenu;

    void Start()
    {
        healthStruct.health = 1000;
    }

    //  Lose health method for children to inherit or override.
    public virtual void LoseHealth(int _damageAmount)
    {
        healthStruct.health -= _damageAmount;
        ui.DisplayHealth(healthStruct.health);
        if (healthStruct.health <= 0) {
            Die();
            ui.DisplayHealth(0);
        }
    }

    //  Die method for children to inherit or override.
    public virtual void Die()
    {
        Debug.Log("Game Over!");
        ui.GameOver();
        ui.DisplayScoreboard();
        scoreBoard.SetActive(true);
        returnToMainMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
