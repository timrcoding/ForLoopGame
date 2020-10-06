using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberBehaviour : MonoBehaviour
{
    private int value;
    [SerializeField]
    private TextMeshProUGUI text;

    //SETS PROPERTY OF VALUE
    [SerializeField]
    private bool initialiser;
    [SerializeField]
    private bool limit;
    [SerializeField]
    private bool incrementer;

    void Start()
    {
        setText();      
    }

    //SET NUMBER TO TEXT
    public void setText()
    {
        text.text = value.ToString();
    }

    //WHEN BUTTON IS PRESSED, INCREMENTS VALUE OF NUMBER, RESETS TO ZERO IF LIMIT IS PASSED
    //ALL VALUES ARE PASSED TO LOOP, WHICH HOLDS THE VALUES FOR USE IN FUNCTION.
    public void incValue()
    {
        animatePush();
        int num = GameManager.instance.lines.Count;
        value++;
        if (initialiser)
        {
            resetValue(num - 1,0);
        }
        else if (limit)
        {
            resetValue(num,0);
        }
        else if (incrementer)
        {
            resetValue(num - 2,1);
        }
        setText();
        setToLoop();
    }
    //COMMITS VALUES TO LOOP BEHAVIOUR ARRAYS
    public void setToLoop()
    {
        if (initialiser)
        {
            LoopBehaviour.instance.initialiserValue = value;
        }
        else if (limit)
        {
            LoopBehaviour.instance.limitValue = value;
        }
        else if (incrementer)
        {
            LoopBehaviour.instance.incrementerValue = value;
        }
    }

    //RESETS VALUE OF NUMBER
    public void resetValue(int i,int j)
    {
        if (value > i)
        {
            value = j;
        }
    }

    //ANIMATES BUTTON
    public void animatePush()
    {
        GetComponent<Animator>().SetTrigger("Press");
    }
}
