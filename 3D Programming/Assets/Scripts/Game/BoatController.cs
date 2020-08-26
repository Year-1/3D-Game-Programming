using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    int gold;
    public UserInterface ui;

//  Checks collision, gains gold if collision is with loot. 
private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == "Loot") {
            Debug.Log("Loot was hit");
            Destroy(_other.gameObject);
            gold += 10;
            ui.DisplayGold(gold);
        }
    }
}
