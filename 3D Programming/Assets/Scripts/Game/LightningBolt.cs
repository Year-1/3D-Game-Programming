using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningBolt : MonoBehaviour
{
    public Sprite[] bolts;

    SpriteRenderer img;

    bool running = true;
    bool sound = true;

    public GameObject player;
    AudioSource audioSource;

    public GameObject lightningLight;

    void Start()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
        img = GetComponent<SpriteRenderer>();
        StartCoroutine(Bolt());
        player = GameObject.FindGameObjectWithTag("BoltLook");
        lightningLight.SetActive(false);
    }

    private void Update()
    {
        if (!running) {
            StopCoroutine(Bolt());
        }
        this.transform.LookAt(player.transform);

        if (sound) {
            audioSource.volume = PlayerPrefs.GetFloat("Sfx");
            audioSource.PlayOneShot(Sounds.sound.lightningBolt);
            sound = false;
        }
    }

    /// <summary>
    ///     Sets the lightning bolt light to active, cycles through the lightninig bolt images until setting it back to null
    ///     then waits for the sound to finish playing before destroying itself.
    /// </summary>
    /// <returns></returns>
    IEnumerator Bolt()
    {
        yield return new WaitForSeconds(0.5f);
        lightningLight.SetActive(true);
        int i = 0;
        while (i < 4) {
            img.sprite = bolts[i];
            yield return new WaitForSeconds(0.05f);
            i++;
        }
        lightningLight.SetActive(false);
        img.sprite = null;
        running = false;
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
