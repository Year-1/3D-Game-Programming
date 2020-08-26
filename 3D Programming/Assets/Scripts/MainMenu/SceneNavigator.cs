using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    //  Loads the game scene.
    public void OpenGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    //  Open the main menu scene
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
