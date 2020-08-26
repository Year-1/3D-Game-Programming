using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public float mouseSens = 2.0f;
    public float horizontal;
    public float vertical;

    public GameObject cameraObj;

    void Update()
    {
        UpdateRotation();
    }

    /// <summary>
    /// 
    /// </summary>
    void UpdateRotation()
    {
        if (Input.GetJoystickNames().Length == 0) {
            horizontal = Input.GetAxis("Mouse X") * mouseSens;
            vertical -= Input.GetAxis("Mouse Y") * mouseSens;
            vertical = Mathf.Clamp(vertical, -80, 80);

            this.transform.Rotate(0, horizontal, 0);
            cameraObj.transform.localRotation = Quaternion.Euler(vertical, 0, 0);
        }
        if (Input.GetJoystickNames().Length == 1) {
            horizontal = Input.GetAxis("Horizontal");
            vertical -= Input.GetAxis("Vertical");
            vertical = Mathf.Clamp(vertical, -80, 80);

            this.transform.Rotate(0, horizontal, 0);
            cameraObj.transform.localRotation = Quaternion.Euler(vertical, 0, 0);
        }
    }
}
