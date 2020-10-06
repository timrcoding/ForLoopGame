using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberBehaviour : MonoBehaviour
{
    public int value;
    public TextMeshProUGUI text;
    public Animator anim;

    //SETS PROPERTY OF VALUE
    public bool initialiser;
    public bool limit;
    public bool incrementer;

    void Start()
    {
        setText();
        //setToLoop();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText()
    {
        text.text = value.ToString();
    }

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

    public void resetValue(int i,int j)
    {
        if (value > i)
        {
            value = j;
        }
    }

    public void animatePush()
    {
        anim.SetTrigger("Press");
    }
}
