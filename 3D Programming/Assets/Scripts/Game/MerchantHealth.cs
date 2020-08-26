using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantHealth : ParentHealth
{
    //  PlayerCannonBall is the cannonballID
    //  If the collision is with player shot, lose health.
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == cannonballID) {
            Destroy(_other.gameObject);
            LoseHealth(100);
            ui.DisplayScoreAnimation();
        }
    }

    //  Merchant loses health.
    public override void LoseHealth(int _damageAmount)
    {
        healthStruct.health -= _damageAmount;
        if (healthStruct.health <= 0) {
            Die();
        }
    }

    //  Drops a reward on death.
    public override void Die()
    {
        var chest = Instantiate(treasure) as GameObject;
        chest.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        chest.transform.rotation = this.transform.rotation;
        chest.transform.localScale = new Vector3(3, 3, 3);
        Destroy(this.gameObject);
    }
}
