using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerManager : MonoBehaviour
{
    public static ClickerManager instance;
    public int score;
    public TextMeshProUGUI scoreText;
    public float colorCounter;
    public Image background;
    void Start()
    {
        instance = this;
    }
    private void Update()
    {
        background.color = Color.HSVToRGB(colorCounter, 0.2f, 1);
        colorCounter += Time.deltaTime * Time.deltaTime;
        if (colorCounter >= 1)
        {
            colorCounter = 0;
        }
    }

    public void incScore()
    {
        score++;
        setScore(score);
    }

    public void setScore(int i)
    {
        scoreText.text = i.ToString();
    }
}
