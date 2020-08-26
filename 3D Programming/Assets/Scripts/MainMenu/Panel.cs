using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public GameObject canvas;
    public GameObject mainMenu;
    public GameObject thisPanel, otherPanel, optionPanel;
    public TMP_InputField usernameInput, passwordInput;
    public GameObject failedAttemptText;
    public GameObject usernameHelpPanel, passwordHelpPanel;
    public GameObject usernameHelpButton, passwordHelpButton;
    public Button submit;
    public MainMenu mainMenuS;
    public CharacterInfo ci; 

    private void Start()
    {
        mainMenuS = canvas.GetComponent<MainMenu>();
        ci = GameObject.FindGameObjectWithTag("CharInfo").GetComponent<CharacterInfo>();
    }

    //  Make the help menus close when anywhere on screen is clicked.
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            passwordHelpPanel.SetActive(false);
            usernameHelpPanel.SetActive(false);
            passwordHelpButton.SetActive(true);
            usernameHelpButton.SetActive(true);
        }
    }
    //  Opens the option panel.
    public void OptionPanel()
    {
        usernameInput.text = "";
        passwordInput.text = "";
        usernameHelpPanel.SetActive(false);
        passwordHelpPanel.SetActive(false);
        failedAttemptText.SetActive(false);
        optionPanel.SetActive(true);
        thisPanel.SetActive(false);
    }

    //  Checks the user inputs for login and register are atleast 4 characters long.
    public void VerifyInputs()
    {
        submit.interactable = (usernameInput.text.Length >= 4 && usernameInput.text.Length <= 12 && passwordInput.text.Length >= 4 && passwordInput.text.Length <= 12);
    }

    //  Open username help panel.
    public void OpenUsernameHelp()
    {
        usernameHelpPanel.SetActive(true);
        usernameHelpButton.SetActive(false);
        passwordHelpPanel.SetActive(false);
    }

    //  Open the password help panel.
    public void OpenPasswordHelp()
    {
        passwordHelpPanel.SetActive(true);
        passwordHelpButton.SetActive(false);
        usernameHelpButton.SetActive(false);
        usernameHelpPanel.SetActive(false);
    }

    //  Close the login help panel.
    public void CloseLoginHelp()
    {
        passwordHelpPanel.SetActive(false);
        passwordHelpButton.SetActive(true);
        usernameHelpPanel.SetActive(false);
        usernameHelpButton.SetActive(true);
    }

    //  Button calls this to register.
    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    //  Button calls this to login.
    public void CallLogIn()
    {
        StartCoroutine(LogIn());
    }


    //  Sends a form to php which inputs it into database.
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

    // Sends a form to php to test it against the database. If the crypted password matches the 
    //  hash stored in the database. Login to the game. 
    IEnumerator LogIn()
    {
        failedAttemptText.SetActive(false);
        string url = "http://3dprogramming1.000webhostapp.com/php/login.php";
        //string url = "http://localhost/php/login.php";
        WWWForm form = new WWWForm();
        form.AddField("name", usernameInput.text);
        form.AddField("password", passwordInput.text);
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.downloadHandler.text == "0") {
            Debug.Log("User logged in succesfully!");
            ci.CharUsername = usernameInput.text;
            ci.LoggedIn = true;
            otherPanel.SetActive(true);
            mainMenuS.MainMenuCall();
            thisPanel.SetActive(false);

        } else {
            Debug.Log("User was not logged in" + www.downloadHandler.text);
            failedAttemptText.SetActive(true);
        }
    }
}
