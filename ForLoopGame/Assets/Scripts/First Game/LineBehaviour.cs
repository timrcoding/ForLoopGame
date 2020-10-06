using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineBehaviour : MonoBehaviour
{
    public int uniqueRef;
    public GameObject vehicle;
    public GameObject target;
    public TextMeshProUGUI indexText;

    
    public bool isTarget;
    void Start()
    {
        
    }

    public void setTarget()
    {
        isTarget = GameManager.instance.correctAnswers[uniqueRef];
        if (isTarget)
        {
            target.GetComponent<Image>().color = GameManager.instance.targetColor;
        }
        else
        {
                target.GetComponent<Image>().color = Color.black;
        }
    }

    public void setIndex()
    {
        indexText.text = uniqueRef.ToString();
    }
}
