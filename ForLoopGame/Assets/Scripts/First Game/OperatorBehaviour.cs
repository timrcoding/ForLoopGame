using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OperatorBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool limitOperator;
    [SerializeField]
    private bool incOperator;

    [SerializeField]
    private TextMeshProUGUI text;

    public int value;
    void Start()
    {
        setText();
    }

    public void incValue()
    {
        GetComponent<Animator>().SetTrigger("Press");
        value++;
        if (value >= 2)
        {
            value = 0;
        }
        setText();
        setToLoop();
    }

    public void setText()
    {
        if (limitOperator)
        {
            if(value == 0)
            {
                text.text = "<";
            }
            else
            {
                text.text = ">";
            }
        }
        else
        {
            if (value == 0)
            {
                text.text = "+=";
            }
            else
            {
                text.text = "-=";
            }
        }
    }

    public void setToLoop()
    {
        if (limitOperator)
        {
            LoopBehaviour.instance.limitOperatorValue = value;
        }
        else
        {
            LoopBehaviour.instance.incOperatorValue = value;
        }
    }
}
