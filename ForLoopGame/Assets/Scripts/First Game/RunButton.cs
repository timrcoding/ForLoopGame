﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunButton : MonoBehaviour
{
    //RUNS LOOP BEHAVIOUR - RUN LOOP FUNCTION
   public void runLoop()
    {
        AudioManager.instance.playClip("Click_02");
        LoopBehaviour.instance.runLoop();
    }

}
