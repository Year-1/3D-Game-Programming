using TMPro;
using UnityEngine;

public class BoatShoot : MonoBehaviour
{
    public GameObject cannonBallForwards,
                      cannonBallLeft,
                      cannonBallRight;

    public Transform playerShip,
                     cannonSpawnForwards,
                     cannonSpawnLeft,
                     cannonSpawnRight;

    public GameObject explosion;

    public TextMeshProUGUI ammoDisplay;

    public UserInterface ui;

    public bool hasShots;
    public int shotCount;

    public float timer;
    public int seconds;

    public float alphaValue = 1.0f;
    public int alphaDir;

    public bool LT = false;
    public bool RT = false;

    private void Start()
    {
        hasShots = true;
        shotCount = 10;
        alphaDir = 1;
    }

    //  Instantiate particle effect on shot
    void FixedUpdate()
    {
        if (hasShots) {
            // Shoots a cannonball, tags the object, plays a particle, decreases the shot count, plays the cannonshot sound then updates the ui.
            if (Input.GetAxisRaw("FireLeft") != 0) {
                if (LT == false) {
                    var cannon = Instantiate(cannonBallLeft) as GameObject;
                    cannon.transform.position = new Vector3(cannonSpawnLeft.position.x, cannonSpawnLeft.position.y, cannonSpawnLeft.position.z);
                    cannon.transform.rotation = playerShip.rotation;
                    var cannonAnim = Instantiate(explosion) as GameObject;
                    cannonAnim.transform.position = new Vector3(cannonSpawnLeft.position.x, cannonSpawnLeft.position.y, cannonSpawnLeft.position.z);
                    cannonAnim.transform.rotation = cannonSpawnLeft.rotation;
                    cannon.gameObject.tag = "PlayerCannonBall";
                    shotCount--;
                    SoundsManager.PlayerSound();
                    ui.DisplayAmmo(shotCount);
                    LT = true;
                }
            }
            if (Input.GetAxisRaw("FireLeft") == 0) {
                LT = false;
            }
            // Shoots a cannonball, tags the object, plays a particle, decreases the shot count, plays the cannonshot sound then updates the ui.
            if (Input.GetAxisRaw("FireRight") != 0) {
                if (RT == false) {
                    var cannon = Instantiate(cannonBallRight) as GameObject;
                    cannon.transform.position = new Vector3(cannonSpawnRight.position.x, cannonSpawnRight.position.y, cannonSpawnRight.position.z);
                    cannon.transform.rotation = playerShip.rotation;
                    cannon.gameObject.tag = "PlayerCannonBall";
                    var cannonAnim = Instantiate(explosion) as GameObject;
                    cannonAnim.transform.position = new Vector3(cannonSpawnRight.position.x, cannonSpawnRight.position.y, cannonSpawnRight.position.z);
                    cannonAnim.transform.rotation = cannonSpawnRight.rotation;
                    shotCount--;
                    SoundsManager.PlayerSound();
                    ui.DisplayAmmo(shotCount);              
                    RT = true;
                }
            }
            if (Input.GetAxisRaw("FireRight") == 0) {
                RT = false;
            }
        }

        if (shotCount == 0) {
            hasShots = false;
            Reload();
        }
    }

    //  Reloads the players ammo. While changing the alpha channel of the text to make it appear
    //  like it flashing.
    void Reload()
    {
        timer += Time.deltaTime;
        seconds = (int)timer;
        if (alphaDir == 1) {
            alphaValue -= Time.deltaTime;
            ammoDisplay.color = new Color(0f, 0f, 0f, alphaValue);
        }
        if (alphaDir == 2) {
            alphaValue += Time.deltaTime;
            ammoDisplay.color = new Color(0f, 0f, 0f, alphaValue);
        }
        if (alphaValue <= 0) {
            alphaDir = 2;
        } else if (alphaValue >= 1) {
            alphaDir = 1;
        }
        if (seconds == 5) {
            hasShots = true;
            shotCount = 10;
            ui.DisplayAmmo(shotCount);
            timer = 0;
            seconds = 0;
            ammoDisplay.color = new Color(0f, 0f, 0f, 1f);
        }
    }
}
