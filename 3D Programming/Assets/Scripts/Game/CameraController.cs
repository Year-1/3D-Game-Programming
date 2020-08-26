using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool pressed = true;

    public GameObject thirdPersonCam;
    public GameObject firstPersonCam;

    private void Start()
    {
        thirdPersonCam.SetActive(true);
        firstPersonCam.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
    }

    /// <summary>
    ///     Changes the camera which is being used to render on button press.
    /// </summary>
    void Update()
    {
        if (Input.GetAxis("CameraController") != 0) {
            if (pressed) {

                thirdPersonCam.SetActive(!thirdPersonCam.activeSelf);
                firstPersonCam.SetActive(!firstPersonCam.activeSelf);

                pressed = false;
            }
        } else {
            pressed = true;
        }
    }
}
