using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineBehaviour : MonoBehaviour
{
    public int uniqueRef;
    public GameObject vehicle;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private TextMeshProUGUI indexText;
    private bool isTarget;
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

    public void moveVehicle()
    {
        vehicle.GetComponent<VehicleBehaviour>().resetPosition();
        vehicle.GetComponent<VehicleBehaviour>().moveObject = true;
    }
}
