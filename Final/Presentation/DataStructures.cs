using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStructures : MonoBehaviour
{
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

//  Array used to cycle through images to make a lightning bolt animation.
public class LightningBolt : MonoBehaviour
{
    public Sprite[] bolts;

    IEnumerator Bolt()
    {
        yield return new WaitForSeconds(0.5f);
        lightningLight.SetActive(true);
        int i = 0;

        //  Loops
        while (i < 4) {
            img.sprite = bolts[i];
            yield return new WaitForSeconds(0.05f);
            i++;
        }


        lightningLight.SetActive(false);
        img.sprite = null;
        running = false;
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

//  Switchcase
    void Switch()
    {
        switch (action) {
            case Action.STATIONARY:
                //  Do stationary logic
                break;

            case Action.PATROLLING:
                //  Do patrolling logic
                break;

            case Action.ATTACKING:
                //  Do attacking logic
                break;

            default:
                //  Tell the programmer default state was reached
        }
    }
}



