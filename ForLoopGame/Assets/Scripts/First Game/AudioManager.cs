using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource AudioS;
    [SerializeField]
    private AudioClip[] robotVoice;
    [SerializeField]
    private bool playRobot;
    private int levelCount;
    void Start()
    {
        
        instance = this;
        //ASSIGNS AUDIO SOURCE
        AudioS = GetComponent<AudioSource>();
        //PLAYS ROBOT VOICE AT START OF SCENE IF APPROPRIATE (MAIN GAME)
        playRobotVoice();
    }

    public void playClip(string clip)
    {
        //LOADS CLIP AS DEFINED BY STRING FROM RESOURCES
        AudioClip clipPlayed = Resources.Load("Sound/" + clip.ToString()) as AudioClip;
        //PLAYS CLIP
        AudioS.PlayOneShot(clipPlayed);
    }

    public void playRobotVoice()
    {
        if (playRobot)
        {
            AudioS.PlayOneShot(robotVoice[levelCount]);
        }
    }

    
}
