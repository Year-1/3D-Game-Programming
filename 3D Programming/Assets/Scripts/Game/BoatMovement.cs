using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BoatMovement : MonoBehaviour
{
    private float speed = 500f; //500
    public float Speed {
        get {return speed; }
        set { speed = value; }
    }

    private float turnSpeed = 5000f; //5000
    public float TurnSpeed {
        get { return turnSpeed; }
        set { turnSpeed = value; }
    }
    private Rigidbody rb;
    private float h, v;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(playMusic());
    }

    void FixedUpdate()
    {
        //  Gets inputs from the input manager.
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Movement(v);
        if (h != 0) {
            Steering(h);
        }
    }

    //  Adds force to the boat to allow it to move forward and slow down. Can not move backwards.
    void Movement(float input)
    {
        if (input > 0) {
            rb.AddForce(transform.forward * input * Time.fixedDeltaTime * speed * -1);
            if (rb.velocity.magnitude >= 40) {
                rb.AddForce(transform.forward * input * Time.fixedDeltaTime * speed * 2);
            }
        }
        if (input < 0) {
            rb.AddForce(transform.forward * input * Time.fixedDeltaTime * speed * -2);
            if (rb.velocity.magnitude > 1) {
                rb.AddForce(transform.forward * input * Time.fixedDeltaTime * speed * 2);
            }
        }
    }

    //  Adds torque so the boat can turn left and right. 
    void Steering(float input)
    {
        rb.AddTorque(0f, input * turnSpeed * Time.fixedDeltaTime, 0f);
        if (rb.velocity.magnitude <= 3) {
            Movement(1);
        }
    }    

    // Plays the background music.
    IEnumerator playMusic()
    {
        yield return new WaitForSeconds(0.25f);
        SoundsManager.BackgroundNoise();
        SoundsManager.Music();
    }
    
}
