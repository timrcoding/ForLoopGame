using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunButton : MonoBehaviour
{
    private bool buttonPressable = true;
    private int runCount;
    //RUNS LOOP BEHAVIOUR - RUN LOOP FUNCTION
   public void runLoop()
    {
        if (buttonPressable)
        {
            AudioManager.instance.playClip("Click_02");
            LoopBehaviour.instance.runLoop();
            buttonPressable = false;
            GetComponent<Image>().color = Color.red;
            GetComponent<Button>().interactable = false;
            runCount++;
            if(runCount >= 3)
            {
                LoopBehaviour.instance.showAnswer();
            }
            StartCoroutine(runCooldown());
        }
    }

    public IEnumerator runCooldown()
    {
        yield return new WaitForSeconds(3);
        buttonPressable = true;
        GetComponent<Image>().color = Color.white;
        GetComponent<Button>().interactable = true;
    }

}
