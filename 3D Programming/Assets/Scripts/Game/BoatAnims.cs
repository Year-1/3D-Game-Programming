using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAnims : MonoBehaviour
{
    public GameObject frontSail, middleSail, backSail;
    float hor;
    float x1, x2;
    bool left, right;

    float maxRotation = 25;
    public float playerRotate, defaultRotateCenter;

    private void Start()
    {
        left = false;
        right = false;
    }

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        //  Make sails turn left by gradually decreasing x1
        if (hor < 0) {
            TurnLeft();
            x1 = Mathf.Clamp(x1 - (Time.deltaTime * playerRotate), -maxRotation, 0);
        } 
        //  Make sails turn right by gradually increasing x2
        else if (hor > 0) {
            TurnRight();
            x2 = Mathf.Clamp(x2 + (Time.deltaTime * playerRotate), 0, maxRotation);
        } 
        //  Center the sails by increasing x1 and decreasing x2
        else if (hor == 0) {
            Centered();
            x1 = Mathf.Clamp(x1 + (Time.deltaTime * defaultRotateCenter), -maxRotation, 0);
            x2 = Mathf.Clamp(x2 - (Time.deltaTime * defaultRotateCenter), 0, maxRotation);
        }
    }

    //  Turns the sails left by gradually decreasing x1
    void TurnLeft()
    {
        frontSail.transform.localRotation = Quaternion.Euler(0, x1, 0);
        middleSail.transform.localRotation = Quaternion.Euler(0, x1, 0);
        backSail.transform.localRotation = Quaternion.Euler(0, x1, 0);

        left = true;
        right = false;
    }

    //  Turns the sails right by gradually increasing x2
    void TurnRight()
    {
        frontSail.transform.localRotation = Quaternion.Euler(0, x2, 0);
        middleSail.transform.localRotation = Quaternion.Euler(0, x2, 0);
        backSail.transform.localRotation = Quaternion.Euler(0, x2, 0);

        right = true;
        left = false;
    }

    //  Centers the sails. By doing the inverse of the turn right and turn left.
    void Centered()
    { 
        if (left) {
            frontSail.transform.localRotation = Quaternion.Euler(0, x1, 0);
            middleSail.transform.localRotation = Quaternion.Euler(0, x1, 0);
            backSail.transform.localRotation = Quaternion.Euler(0, x1, 0);
        }
        if (right) {
            frontSail.transform.localRotation = Quaternion.Euler(0, x2, 0);
            middleSail.transform.localRotation = Quaternion.Euler(0, x2, 0);
            backSail.transform.localRotation = Quaternion.Euler(0, x2, 0);
        }
    }

}
