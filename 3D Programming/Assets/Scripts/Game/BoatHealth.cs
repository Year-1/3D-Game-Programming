using UnityEngine;

namespace LowPolyWater
{
    public class BoatHealth : ParentHealth
    {
        public StormController storm;
        public bool startStorm = true;

        //  PirateCanonBall is the cannonballID.
        //  Checks if the boat colided with a cannonball.
        private void OnTriggerEnter(Collider _other)
        {
            if (_other.gameObject.tag == cannonballID) {
                Destroy(_other.gameObject);
                LoseHealth(100);
            }
        }

        private void Update()
        {
            if(healthStruct.health <= 800) {
                if (startStorm) {
                    StartCoroutine(storm.StartStorm());
                    startStorm = false;
                }
            }
        }
    }
}
