using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip whistle;
    public AudioClip cheer;
    public AudioClip warning;
    public AudioClip wrongAnswer;
    public AudioClip crash;
    public AudioClip yeah;
    public AudioSource AudioS;
    public AudioClip weee;
    public AudioClip club;

    public AudioClip[] robotVoice;
    void Start()
    {
        instance = this;
        AudioS.PlayOneShot(robotVoice[LevelCounter.instance.count]);
    }

    
}
