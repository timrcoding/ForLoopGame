using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    public static LevelCounter instance;
    //MUST BE PUBLIC AS ACCESSED IN OTHER SCRIPTS
    public int count;
    void Start()
    {
        instance = this;
    }

}
