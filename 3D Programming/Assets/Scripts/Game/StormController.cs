using System.Collections;
using UnityEngine;

namespace LowPolyWater
{
    public class StormController : MonoBehaviour
    {
        public GameObject lightningBolt;

        public LowPolyWater lpw;

        public Light dirLight;
        float intensity;

        public GameObject rain;
        public GameObject rainSpawn;
        public BoatMovement player;

        private bool startStorm;
        bool runOnce;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoatMovement>();
            intensity = dirLight.intensity;
            startStorm = false;
            runOnce = true;

        }

        /// <summary>
        ///     Checks whether or not to start the storm, if so all the storm related functions will be called.
        /// </summary>
        private void Update()
        {
            if (startStorm == true) {
                DarkSky();
                StormWater();
                player.TurnSpeed = 2500f;
                player.Speed = 250f;
                if (runOnce) {
                    StartCoroutine(SpawnBolt());
                    StartCoroutine(SpawnBolt());
                    StartCoroutine(SpawnBolt());
                    Rain();
                    runOnce = false;
                }
            }
            if (startStorm == false) {
                LightSky();
            }
        }

        public IEnumerator StartStorm()
        {
            runOnce = true;
            startStorm = true;
            yield return new WaitForSeconds(30f);
            EndStorm();
        }

        void EndStorm()
        {
            startStorm = false;
            ClearSky();
            NormalWater();
            player.TurnSpeed = 5000f;
            player.Speed = 500f;
            StopAllCoroutines();
        }

        /// <summary>
        ///     Spawns a lightning bolt at random intervals within the bounds of the map.
        /// </summary>
        /// <returns></returns>
        IEnumerator SpawnBolt()
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            for (int i = 0; i < 100; i++) {
                Vector3 spawn = new Vector3(Random.Range(-1200, 1200), 225, Random.Range(-1200, 1200));
                Instantiate(lightningBolt, spawn, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(2.25f, 2.75f));
            }
        }

        /// <summary>
        ///     Increases the waveheight and frequency to better match storm conditions.
        /// </summary>
        void StormWater()
        {
            lpw.WaveHeight = 5f;
            lpw.WaveFrequency = .75f;
            lpw.WaveLength = 10f;
        }

        /// <summary>
        ///     Drecreases the waveheight and frequency to better match storm conditions.
        /// </summary>
        void NormalWater()
        {
            lpw.WaveHeight = 2f;
            lpw.WaveFrequency = .5f;
            lpw.WaveLength = 10f;
        }

        /// <summary>
        ///     Gradually darkens the lighting in the scene.
        /// </summary>
        void DarkSky()
        {
            float scale = .25f;
            dirLight.intensity = Mathf.Clamp(intensity -= Time.deltaTime * scale, 0.3f, 1f);
            if (intensity <= .3f) intensity = .3f;
            RenderSettings.fog = true;

        }

        /// <summary>
        ///     Gradually lightens the lighting in the scene.
        /// </summary>
        void LightSky()
        {
            float scale = .25f;
            dirLight.intensity = Mathf.Clamp(intensity += Time.deltaTime * scale, 0.3f, 1f);
            if (intensity >= 1f) intensity = 1f;
        }

        /// <summary>
        ///     Adds the rain particle effects near the camera to simulate rain.
        /// </summary>
        void Rain()
        {
            Instantiate(rain, rainSpawn.transform);
        }

        /// <summary>
        ///     Removes the rain particle system object and disables the fog.
        /// </summary>
        void ClearSky()
        {
            GameObject rainGO = GameObject.FindGameObjectWithTag("Rain");
            Destroy(rainGO);
            RenderSettings.fog = false;
        }
    }
}
