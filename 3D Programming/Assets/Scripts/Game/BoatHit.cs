using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHit : MonoBehaviour
{
    public GameObject scoreAnim;
    public RectTransform scoreDisplay;

    public UserInterface ui;

    //  Gives the player score for hitting an enemy ship.
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == "PlayerCannonBall") {
            Debug.Log("Boat was hit");
            Destroy(_other.gameObject);
            ui.DisplayScoreAnimation();
        }
    }
}
