using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public AudioSource audioS;
    public GameObject canvas;
    public float audioTime;
    public bool canvasOn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioTime = audioS.time;
        if (!canvasOn)
        {
            if (audioS.time > 120)
            {
                canvasOn = true;
                canvas.SetActive(true);
            }
        }
    }
}
