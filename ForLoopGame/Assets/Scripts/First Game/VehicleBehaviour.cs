using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehaviour : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField]
    private GameObject target;
    //PUBLIC AS ACCESSED IN OTHER FUNCTIONS
    public bool moveObject;
    [SerializeField]
    private float lerpSpeed;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //LERPS OBJECT TO TARGET POSITION. THIS IS A RARE OCCASION OF A FUNCTION RUNNING IN UPDATE, AS THIS IS NECESSARY FOR LERP.
        if (moveObject)
        {
            moveObject = true;
            transform.position = Vector3.Lerp(transform.position, target.transform.position, lerpSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position,target.transform.position) < 0.05f)
            {
                moveObject = false;
            }
        }
        
    }
    //RESETS POSITION OF OBJECT
    public void resetPosition()
    {
        transform.position = startPos;
    }
}
