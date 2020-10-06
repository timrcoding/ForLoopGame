using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //CHANGES LEVEL ON CONTACT
        if(other.tag == "Cookie")
        {
            AsyncLoad.instance.switchChangeLevel();
        }
    }
}
