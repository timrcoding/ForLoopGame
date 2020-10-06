using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopBehaviour : MonoBehaviour
{
    public static LoopBehaviour instance;

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
            AudioManager.instance.AudioS.PlayOneShot(AudioManager.instance.warning);
        }
        
    }

    public void moveObject(int i)
    {
        GameManager.instance.lines[i].GetComponent<LineBehaviour>().vehicle.GetComponent<VehicleBehaviour>().resetPosition();
        GameManager.instance.lines[i].GetComponent<LineBehaviour>().vehicle.GetComponent<VehicleBehaviour>().moveObject = true;
        GameManager.instance.activated[i] = true;
        AudioManager.instance.AudioS.PlayOneShot(AudioManager.instance.whistle);
    }

    

}
