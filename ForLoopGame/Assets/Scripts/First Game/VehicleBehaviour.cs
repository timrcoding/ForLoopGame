using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehaviour : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField]
    private GameObject target;
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

    public void resetPosition()
    {
        transform.position = startPos;
    }
}
