using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotation : MonoBehaviour
{
    /// <summary>
    ///     Changes the pirates rotation to be able to shoot cannons at the player.
    /// </summary>
    public void AttackingRotation()
    {
        this.gameObject.transform.localEulerAngles = new Vector3(0, 90, 0);
    }

    /// <summary>
    ///     Changes the pirates rotation to be able to patroll.
    public void PatrollingRotation()
    {
        this.gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
    }
}
