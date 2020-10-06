using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopBehaviour : MonoBehaviour
{
    public static LoopBehaviour instance;
    //ALL VALUES ARE PUBLIC AS ACCESSED BY OTHER SCRIPTS
    public int initialiserValue;
    public int limitValue;
    public int incrementerValue;
    public int limitOperatorValue;
    public int incOperatorValue;

    public TextMeshProUGUI warningText;
    void Start()
    {
        instance = this;
        warningText.text = "";

    }
    //SETS UP FOR LOOP TO RUN, ONLY ALLOWS FOR TWO SETS OF CONDITIONS 
    //1. LOOP LIMIT IS HIGHER THAN INITIALISER, < IS USED AND INCREMENTER != 0
    //2. LOOP LIMIT IS LOWER THAN INITIALISER, > IS USED AND INCREMENTER != 0
    //IN ALL OTHER CONDITIONS, A WARNING SOUND IS PLAYED AND THE FUNCTION DOES NOT RUN
    public void runLoop()
    {
        warningText.text = "";
        GameManager.instance.clearActivatedArray();

        if (limitOperatorValue == 0 && incOperatorValue == 0 && initialiserValue < limitValue && incrementerValue != 0)
        {
            
            Debug.Log("UP LOOP");
            for(int i = initialiserValue; i < limitValue; i += incrementerValue)
            {
                moveObject(i);
            }
            GameManager.instance.checkForCorrectness();
        }
        else if (limitOperatorValue == 1 && incOperatorValue == 1 && initialiserValue > limitValue && incrementerValue != 0)
        {
            Debug.Log("DOWN LOOP");
            for (int i = initialiserValue; i > limitValue; i -= incrementerValue)
            {
                moveObject(i);
            }
            GameManager.instance.checkForCorrectness();
        }
        else
        {
            warningText.text = "Warning! This will break or not run!";
            AudioManager.instance.playClip("Warning");
        }
        
    }

    public void moveObject(int i)
    {
        GameManager.instance.lines[i].GetComponent<LineBehaviour>().moveVehicle();
        GameManager.instance.activated[i] = true;
        AudioManager.instance.playClip("SlideWhistle");
    }

    

}
