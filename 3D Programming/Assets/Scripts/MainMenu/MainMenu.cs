using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    //  Reference to the EventSystem.
    public EventSystem es;

    //  References to the canvas.
    public RectTransform canvas;
    public float canvasHeight;

    //  MainMenu References
    public GameObject mainMenuPanel;
    public TextMeshProUGUI userDisplay;

    [Header("Buttons")]
    //  Buttons to grow depending on select.
    public GameObject[] buttons;
    public RectTransform[] buttonSize;
    public GameObject currentButton;
    public RectTransform currentButonRect;
    public float buttonHeight;
    public int currentButtonIndex;
    bool menuMovement = true;
    bool menuSubmit = true;

    [Header("Panels")]
    public GameObject registerPanel;
    public GameObject loginPanel;
    public GameObject settingsPanel;
    public GameObject characterPanel;

    [Header("Other")]
    //  Getting references to the Option UI.
    public GameObject optionPanel;
    CharacterInfo ci;

    //  Colour pallette.
    Color white = Color.white;
    Color myGrey = new Color(0.75f, 0.75f, 0.75f);

    //  Initialise the currentMenuIndex, buttonSize and Colour.
    private void Start()
    {
        ci = GameObject.FindGameObjectWithTag("CharInfo").GetComponent<CharacterInfo>();

        canvasHeight = canvas.rect.height;
        buttonHeight = canvasHeight / (buttons.Length + 1);
        buttonSize = new RectTransform[buttons.Length];
        for (int i = 0; i < buttons.Length; i++) {
            buttonSize[i] = buttons[i].GetComponent<RectTransform>();
        }
        for (int i = 0; i < buttons.Length; i++) {
            buttonSize[i].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight);
        }
        currentButton = buttons[0];
        currentButonRect = currentButton.GetComponent<RectTransform>();
        currentButonRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight * 2);
        buttonSize[currentButtonIndex].GetComponent<Image>().color = myGrey;
    }

    //  Changes the button size of which button is currently selected via currentMenuIndex, makes it 2x larger and changes the colour to grey.
    //  while the others are set to white and 1x size.
    private void Update()
    {
        if (mainMenuPanel.activeSelf)
        {
            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                if (menuMovement)
                {
                    if (currentButtonIndex == 0) currentButtonIndex = 4;
                    currentButtonIndex--;
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttonSize[i].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight);
                        buttonSize[i].GetComponent<Image>().color = white;
                    }
                    buttonSize[currentButtonIndex].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight * 2);
                    buttonSize[currentButtonIndex].GetComponent<Image>().color = myGrey;
                    menuMovement = false;
                }
            }
            else if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                if (menuMovement)
                {
                    if (currentButtonIndex == 3) currentButtonIndex = -1;
                    currentButtonIndex++;
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttonSize[i].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight);
                        buttonSize[i].GetComponent<Image>().color = white;
                    }
                    buttonSize[currentButtonIndex].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight * 2);
                    buttonSize[currentButtonIndex].GetComponent<Image>().color = myGrey;
                    menuMovement = false;
                }
            }
            else { menuMovement = true; }

            if (Input.GetAxis("Submit") != 0)
            {
                if (menuSubmit)
                    buttons[currentButtonIndex].GetComponent<Button>().onClick.Invoke();
                menuSubmit = false;
            }
            else { menuSubmit = true; }
        }
    }

    //  Open the character panel.
    public void CharacterPanel()
    {
        characterPanel.SetActive(true);
    }

    //  Open the settings panel.
    public void SettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    //  Open the login panel.
    public void LoginPanel()
    {
        loginPanel.SetActive(true);
        optionPanel.SetActive(false);
    }

    //  Opent the register panel.
    public void RegisterPanel()
    {
        registerPanel.SetActive(true);
        optionPanel.SetActive(false);
    }

    //  Exits the game.
    public void ExitGame()
    {
        Application.Quit();
    }

    //  Displays the logged in username on the main menu.
    public void MainMenuCall()
    {
        userDisplay.text = ci.CharUsername;
    }

    //  Used for debugging
    public void MakeMenuTrue()
    {
        mainMenuPanel.SetActive(true);
        optionPanel.SetActive(false);
        ci.CharUsername = "Debugging";
        ci.LoggedIn = true;
    }
}
