using System.Collections;
using UnityEngine;

//  Determines which cannon to shoot from.
public enum SideShoot
{
    LEFT,
    RIGHT,
    FORWARDS
}

public class PirateShoot : MonoBehaviour
{
    public SideShoot sideShoot;

    public GameObject cannonBallForwards,
        cannonBallLeft,
        cannonBallRight;

    public Transform pirateShip,
        cannonSpawnForwards,
        cannonSpawnLeft,
        cannonSpawnRight;

    public void Shoot()
    {
        if (sideShoot == SideShoot.LEFT) {
            ShootLeft();
        }
        if (sideShoot == SideShoot.RIGHT) {
            ShootRight();
        }
        if (sideShoot == SideShoot.FORWARDS) {
            ShootForwards();
        }
    }

    /// <summary>
    ///     Shoots a cannonball from the left of the cannon.
    /// </summary>
    void ShootLeft()
    {
        StartCoroutine(Shoot(cannonBallLeft, cannonSpawnLeft));
    }

    /// <summary>
    ///     Shoots a cannonball from the right of the cannon.
    /// </summary>
    void ShootRight()
    {
        StartCoroutine(Shoot(cannonBallRight, cannonSpawnRight));
    }

    /// <summary>
    ///     Shoots a cannonball from the front of the cannon.
    /// </summary>
    void ShootForwards()
    {
        StartCoroutine(Shoot(cannonBallForwards, cannonSpawnForwards));
    }

    /// <summary>
    ///     Stops the pirates from shooting.
    /// </summary>
    public void StopShooting()
    {
        StopAllCoroutines();
    }

    //  Shoots continously every 5 seconds. Takes which cannonball to shoot and from which cannon.
    IEnumerator Shoot(GameObject cannonBall, Transform cannonPos)
    {
        yield return new WaitForSeconds(2f);
        while (true) {
            var cannon = Instantiate(cannonBall) as GameObject;
            cannon.transform.position = new Vector3(cannonPos.position.x, cannonPos.position.y, cannonPos.position.z);
            cannon.transform.rotation = pirateShip.rotation;
            cannon.gameObject.tag = "PirateCannonBall";

            yield return new WaitForSeconds(5f);
        }
    }
}
