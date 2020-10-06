using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    public static LevelCounter instance;
    public int count;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
