using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public static Clicker instance;
    void Start()
    {
        instance = this;
    }
    //ANIMATES CLICKER WHEN PRESSED
    public void click()
    {
        GetComponent<Animator>().SetTrigger("Press");
        ClickerManager.instance.incScore();
    }
}
