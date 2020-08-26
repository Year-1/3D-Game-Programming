using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject optionsPanel, mainMenu, thisPanel;

    //  Close the character panel.
    public void CloseCharacter()
    {
        thisPanel.SetActive(false);
    }

    public void LogOut()
    {
        //  Have player log out here.
        optionsPanel.SetActive(true);
        mainMenu.SetActive(false);
        thisPanel.SetActive(false);
    }
}
