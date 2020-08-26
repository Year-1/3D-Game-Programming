using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject thisPanel;
    public GameObject mainMenu;

    //  Closes the settings main menu panel.
    public void CloseSettings()
    {
        thisPanel.SetActive(false);
    }
}
