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
    //PUBLIC AS USED IN OTHER SCRIPTS
    public int value;
    void Start()
    {
        setText();
    }
    //INCREMENTS VALUE THAT DEFINES OPERATOR, RESETS WHEN PASSES LIMIT OF 1
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
    //SETS OPERATOR TO APPROPRIATE SYMBOLS IN TEXT
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
    //COMMITS VALUES TO LOOP BEHAVIOUR ARRAYS
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
