using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateLookAt : MonoBehaviour
{
    public Transform target;

    void Awake()
    {
        transform.LookAt(target);
    }

    //  Pirate looks at the player so they can shoot.
    private void Update()
    {        
        transform.LookAt(target);
    }
}
