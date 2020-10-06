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
        AudioS = GetComponent<AudioSource>();
        instance = this;
        if (playRobot)
        {
            AudioS.PlayOneShot(robotVoice[levelCount]);
        }
    }

    public void playClip(string clip)
    {
        AudioClip clipPlayed = Resources.Load("Sound/" + clip.ToString()) as AudioClip;
        AudioS.PlayOneShot(clipPlayed);
    }

    
}
