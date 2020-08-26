using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float duration;

    private void Start()
    {
        StartCoroutine(SelfDestructMethod());
    }

    //  Destroys its self after x amount of seconds.
    IEnumerator SelfDestructMethod()
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}
