using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineBehaviour : MonoBehaviour
{
    public int uniqueRef;
    //MUST BE PUBLIC AS ACCESSED IN OTHER SCRIPTS
    public GameObject vehicle;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private TextMeshProUGUI indexText;
    private bool isTarget;

    //SETS THE COLOR OF THE TARGET COOKIE JAR, BROWN FOR TRUE, RED FOR FALSE.
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

    //SETS INDEX OF LINE TO ADJACENT TEXT
    public void setIndex()
    {
        indexText.text = uniqueRef.ToString();
    }

    //MOVES THE VEHICLE IF SELECTED
    public void moveVehicle()
    {
        vehicle.GetComponent<VehicleBehaviour>().resetPosition();
        vehicle.GetComponent<VehicleBehaviour>().moveObject = true;
    }
}
