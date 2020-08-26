using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class CannonShot : MonoBehaviour
{
    public enum Cannon { Forward, Left, Right };
    public Cannon cannon;

    Rigidbody rb;
    int speed = 100;

    public float timeBefoeSD;

    //  Could make it destroy another way but this works for now.
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(SelfDestruct());
    }

    private void Update()
    {
        //  Shoots a cannonball forwards.
        if (cannon == Cannon.Forward) {
            rb.velocity = -transform.forward * speed;
        }
        //  Shoots a cannonball to the left.
        if (cannon == Cannon.Left) {
            rb.velocity = transform.right * speed;
        }
        //  Shoots a cannonball to the right.
        if (cannon == Cannon.Right) {
            rb.velocity = -transform.right * speed;
        }
    }

    //  Destroys the cannonball after x amount of time.
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeBefoeSD);
        Destroy(this.gameObject);
    }
}
