using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerManager : MonoBehaviour
{
    public static ClickerManager instance;
    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private float colorCounter;
    [SerializeField]
    private Image background;
    void Start()
    {
        instance = this;
    }
    //CHANGES BACKGROUND BY HSV SLOWLY, GOING FROM PINK ALL THE WAY ROUND THE COLOR WHEEL
    private void Update()
    {
        background.color = Color.HSVToRGB(colorCounter, 0.2f, 1);
        colorCounter += Time.deltaTime * Time.deltaTime;
        if (colorCounter >= 1)
        {
            colorCounter = 0;
        }
    }
    //INCREMENTS SCORE
    public void incScore()
    {
        score++;
        setScore(score);
        if(score %10 == 0)
        {
            AudioManager.instance.playClip("Cheer");
        }
    }
    //SETS SCORE TO TEXT
    public void setScore(int i)
    {
        scoreText.text = i.ToString();
    }
}
