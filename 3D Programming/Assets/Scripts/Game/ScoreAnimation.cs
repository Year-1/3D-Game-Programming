using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAnimation : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float moveSpeed = 100.0f;
    public float alphaValue = 1.0f;
    int score;

    private void Start()
    {
        textDisplay = GetComponent<TextMeshProUGUI>();
    }

    //  Makes the score text translate up and slowly lose alpha value. Makes it dissappear.
    void Update()
    {
        if (alphaValue <= 0.0f) {
            Destroy(this.gameObject);
        } else {
            this.transform.Translate(new Vector2(0, moveSpeed) * Time.deltaTime);
            alphaValue -= Time.deltaTime;
            textDisplay.color = new Color(0f, 0f, 0f, alphaValue);
        }
    }

    //  Gives the score value in the animation.
    public void Score(int _score)
    {
        textDisplay.text = "+" + _score.ToString();
    }
}
