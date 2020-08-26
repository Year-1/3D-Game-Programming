using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class Tab : MonoBehaviour
{
    TMP_InputField thisInput;
    public TMP_InputField otherInput;

    private void Start()
    {
        thisInput = GetComponent<TMP_InputField>();
    }

    void Update()
    {
        //  Switches input between input fields. Makes login/register more intuative.
        if (thisInput.isFocused && Input.GetKeyDown(KeyCode.Tab))
        {
            otherInput.ActivateInputField();
        }
    }
}
