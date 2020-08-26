using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStructures : MonoBehaviour
{
    //  These are 3 of the data structures used while creating the game.
    //  1/3
}

//  Enum used for collision detection.
public enum Collisions
{
    MERCHANT,
    PIRATE
}
public class Enum : MonoBehaviour
{
    public Collisions collisions;
}

//  Struct used to hold. Player, Merchant and Pirate health.


public class ParentHealth : MonoBehaviour
{
    public struct Health
    {
        public int health;
    }

    public Health healthStruct;
}