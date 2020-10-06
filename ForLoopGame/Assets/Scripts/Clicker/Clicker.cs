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

    public void click()
    {
        GetComponent<Animator>().SetTrigger("Press");
        ClickerManager.instance.incScore();
    }
}
